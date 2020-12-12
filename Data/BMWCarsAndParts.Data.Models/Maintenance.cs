using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;

namespace BMWCarsAndParts.Data.Models
{
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
