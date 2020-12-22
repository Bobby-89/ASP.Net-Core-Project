namespace BMWCarsAndParts.Services.Data
{
    using BMWCarsAndParts.Web.ViewModels.Cars;

    public interface ICarsService
    {
        void Create(CreateCarInputModel input);
    }
}
