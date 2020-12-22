namespace BMWCarsAndParts.Web.ViewModels.Cars
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using BMWCarsAndParts.Data.Models;

    public class CreateCarInputModel
    {
        [Required]
        [Display(Name = "Model")]
        public int CarModelId { get; set; }

        [Display(Name = "First registration (date)")]
        //// [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        //// [DataType(DataType.Date)]
        public DateTime FirstRegistrationDate { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int Mileage { get; set; }

        [Required]
        [Display(Name = "Vehicle type")]
        public int CarBodyTypeId { get; set; }

        public FuelType Fuel { get; set; }

        [Required]
        [Range(500, 6000)]
        [Display(Name = "Engine cubic centimeters")]
        public int EngineCC { get; set; }

        [Required]
        [Range(50, 1500)]
        [Display(Name = "Horse power (hp)")]
        public int HorsePower { get; set; }

        public string Transmission { get; set; }

        [Display(Name = "Wheel drive")]
        public WheelDrive WheelDrive { get; set; }

        public CarColor Color { get; set; }

        [Required]
        [Range(1, 10000000)]
        public decimal Price { get; set; }

        [Required]
        [MinLength(10)]
        public string Description { get; set; }

        [Display(Name = "For sale")]
        public bool IsForSale { get; set; }

        public IEnumerable<KeyValuePair<string, string>> BodyTypes { get; set; }

        public IEnumerable<KeyValuePair<string, string>> ModelTypes { get; set; }

        //// public string OwnerId { get; set; } //???
    }
}
