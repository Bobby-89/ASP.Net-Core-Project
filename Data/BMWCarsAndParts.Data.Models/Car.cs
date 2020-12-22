namespace BMWCarsAndParts.Data.Models
{
    using System;
    using System.Collections.Generic;

    using BMWCarsAndParts.Data.Common.Models;

    public class Car : BaseDeletableModel<int>
    {
        public Car()
        {
            this.Images = new HashSet<Image>();
        }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public DateTime FirstRegistrationDate { get; set; }

        public int Mileage { get; set; }

        public int CarBodyTypeId { get; set; }

        public virtual CarBodyType CarBodyType { get; set; }

        public FuelType Fuel { get; set; }

        public int EngineCC { get; set; }

        public int HorsePower { get; set; }

        public string Transmission { get; set; }

        public WheelDrive WheelDrive { get; set; }

        public CarColor Color { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsForSale { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public string ImageId { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
