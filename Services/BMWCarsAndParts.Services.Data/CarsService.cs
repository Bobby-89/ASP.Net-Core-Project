namespace BMWCarsAndParts.Services.Data
{
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
    }
}
