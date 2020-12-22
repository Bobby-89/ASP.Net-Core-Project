namespace BMWCarsAndParts.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using BMWCarsAndParts.Data.Common.Models;

    public class Maintenance : BaseDeletableModel<int>
    {
        [Required]
        public int DiaryId { get; set; }

        public virtual Diary Diary { get; set; }

        public DateTime DateOfMaintenance { get; set; }

        [Required]
        public int Mileage { get; set; }

        [Required]
        public string Description { get; set; }


    }
}
