namespace BMWCarsAndParts.Services.Data
{
    using System.Linq;

    using BMWCarsAndParts.Data.Common.Repositories;
    using BMWCarsAndParts.Data.Models;
    using BMWCarsAndParts.Web.ViewModels.Home;

    public class GetCountService : IGetCountService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;
        private readonly IDeletableEntityRepository<Car> carsRepository;
        private readonly IDeletableEntityRepository<PartForSale> partsRepository;
        private readonly IDeletableEntityRepository<CarBodyType> carBodyTypesRepository;

        public GetCountService(
            IDeletableEntityRepository<ApplicationUser> usersRepository,
            IDeletableEntityRepository<Car> carsRepository,
            IDeletableEntityRepository<PartForSale> partsRepository,
            IDeletableEntityRepository<CarBodyType> carBodyTypesRepository)
        {
            this.usersRepository = usersRepository;
            this.carsRepository = carsRepository;
            this.partsRepository = partsRepository;
            this.carBodyTypesRepository = carBodyTypesRepository;
        }

        public IndexViewModel GetCounts()
        {
            var data = new IndexViewModel
            {
                UsersCount = this.usersRepository.All().Count(),
                CarsCount = this.carsRepository.All().Count(),
                PartsCount = this.partsRepository.All().Count(),
                CarTypesCount = this.carBodyTypesRepository.All().Count(),
            };

            return data;
        }
    }
}
