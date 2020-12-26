namespace BMWCarsAndParts.Web.ViewModels.Cars
{
    using System.Collections.Generic;

    public class CarsListViewModel
    {
        public IEnumerable<CarInListViewModel> Cars { get; set; }

        public int PageNumber { get; set; }
    }
}