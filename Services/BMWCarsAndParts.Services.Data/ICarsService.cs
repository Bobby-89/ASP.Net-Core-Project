namespace BMWCarsAndParts.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using BMWCarsAndParts.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task CreateAsync(CreateCarInputModel input, string userId);

        IEnumerable<CarInListViewModel> GetAll(int page, int itemsPerPage = 8);

        int GetCount();
    }
}
