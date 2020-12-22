namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;

    public interface ICarModelsService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
