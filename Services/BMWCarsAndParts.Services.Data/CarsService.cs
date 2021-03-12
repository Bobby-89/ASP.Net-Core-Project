using BMWCarsAndParts.Services.Mapping;

namespace BMWCarsAndParts.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using BMWCarsAndParts.Data.Common.Repositories;
    using BMWCarsAndParts.Data.Models;
    using BMWCarsAndParts.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly string[] allowedExtensions = new[] { "jpg", "png", "gif" };
        private readonly IDeletableEntityRepository<Car> carRepository;

        public CarsService(IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarInputModel input, string userId, string imagePath)
        {
            var car = new Car
            {
                CarModelId = input.CarModelId,
                Fuel = input.Fuel,
                CarBodyTypeId = input.CarBodyTypeId,
                Description = input.Description,
                Color = input.Color,
                EngineCC = input.EngineCC,
                FirstRegistrationDate = input.FirstRegistrationDate,
                HorsePower = input.HorsePower,
                OwnerId = userId,
                Price = input.Price,
                IsForSale = input.IsForSale,
                Mileage = input.Mileage,
                WheelDrive = input.WheelDrive,
                Transmission = input.Transmission,
            };

            // /wwwroot/images/cars/{id}.{ext}
            Directory.CreateDirectory($"{imagePath}/cars/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');

                if (!this.allowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extention {extension}");
                }

                var dbImage = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                car.Images.Add(dbImage);

                var physicalPath = $"{imagePath}/cars/{dbImage.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.carRepository.AddAsync(car);
            await this.carRepository.SaveChangesAsync();
        }

        public IEnumerable<CarInListViewModel> GetAll(int page, int itemsPerPage = 8)
        {
            var cars = this.carRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * 8).Take(itemsPerPage)
                .Select(x => new CarInListViewModel
                {
                    Id = x.Id,
                    CarModel = x.CarModel.Name,
                    Price = x.Price,
                    ImageUrl =
                        x.Images.FirstOrDefault().RemoteImageUrl != null ?
                        x.Images.FirstOrDefault().RemoteImageUrl :
                        "/images/cars/" + x.Images.FirstOrDefault().Id + "." + x.Images.FirstOrDefault().Extension,
                }).ToList();
            return cars;
        }

        public T GetById<T>(int id)
        {
            var car = this.carRepository.AllAsNoTracking().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return car;
        }

        public int GetCount()
        {
            return this.carRepository.All().Count();
        }
    }
}
