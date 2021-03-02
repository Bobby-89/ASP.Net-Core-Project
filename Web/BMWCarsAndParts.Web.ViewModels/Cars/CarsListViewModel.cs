namespace BMWCarsAndParts.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;

    public class CarsListViewModel
    {
        public IEnumerable<CarInListViewModel> Cars { get; set; }

        public int PageNumber { get; set; }

        public bool HasPriviousePage => this.PageNumber > 1;

        public int PreviousePageNumber => this.PageNumber - 1;

        public bool HasNextPage => this.PageNumber < this.PageCount;

        public int NextPageNumber => this.PageNumber + 1;

        public int PageCount => (int)Math.Ceiling((double)this.CarsCount / this.ItemsPerPage);

        public int CarsCount { get; set; }

        public int ItemsPerPage { get; set; }
    }
}