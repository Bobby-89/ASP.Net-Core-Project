namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BMWCarsAndParts.Data.Common.Repositories;
    using BMWCarsAndParts.Data.Models;

    public class CarModelsService : ICarModelsService
    {
        private readonly IDeletableEntityRepository<CarModel> carModelRepository;

        public CarModelsService(IDeletableEntityRepository<CarModel> carModelRepository)
        {
            this.carModelRepository = carModelRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.carModelRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.Name,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name)).OrderBy(x => x.Value);
        }
    }
}
