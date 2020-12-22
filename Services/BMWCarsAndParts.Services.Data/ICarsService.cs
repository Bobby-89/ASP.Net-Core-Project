namespace BMWCarsAndParts.Services.Data
{
    using System.Threading.Tasks;

    using BMWCarsAndParts.Web.ViewModels.Cars;

    public interface ICarsService
    {
        Task CreateAsync(CreateCarInputModel input);
    }
}
