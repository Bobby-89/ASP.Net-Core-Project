namespace BMWCarsAndParts.Services.Data
{
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

        public void Create(CreateCarInputModel input)
        {
            var car = new Car();
        }
    }
}
