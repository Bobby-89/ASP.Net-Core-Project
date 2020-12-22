namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;

    public interface IBodyTypesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
