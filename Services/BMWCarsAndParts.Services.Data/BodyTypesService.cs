namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using BMWCarsAndParts.Data.Common.Repositories;
    using BMWCarsAndParts.Data.Models;

    public class BodyTypesService : IBodyTypesService
    {
        private readonly IDeletableEntityRepository<CarBodyType> carBodyTypesRepository;

        public BodyTypesService(IDeletableEntityRepository<CarBodyType> carBodyTypesRepository)
        {
            this.carBodyTypesRepository = carBodyTypesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.carBodyTypesRepository.AllAsNoTracking().Select(x => new
            {
                x.Id,
                x.BodyType,
            }).ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.BodyType));
        }
    }
}
