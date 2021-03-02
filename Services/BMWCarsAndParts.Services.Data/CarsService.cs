using System.Linq;

namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BMWCarsAndParts.Data.Common.Repositories;
    using BMWCarsAndParts.Data.Models;
    using BMWCarsAndParts.Web.ViewModels.Cars;

    public class CarsService : ICarsService
    {
        private readonly IDeletableEntityRepository<Car> carRepository;

        public CarsService(IDeletableEntityRepository<Car> carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task CreateAsync(CreateCarInputModel input, string userId)
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
            };

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

        public int GetCount()
        {
            return this.carRepository.All().Count();
        }
    }
}
