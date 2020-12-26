namespace BMWCarsAndParts.Web.ViewModels.Cars
{
    using System;

    using BMWCarsAndParts.Data.Models;
    using BMWCarsAndParts.Services.Mapping;

    public class CarInListViewModel : IMapFrom<Car>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string CarModel { get; set; }

        public DateTime FirstRegistrationDate { get; set; }

        public decimal Price { get; set; }
    }
}
