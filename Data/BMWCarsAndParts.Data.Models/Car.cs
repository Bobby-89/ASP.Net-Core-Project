using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;

namespace BMWCarsAndParts.Data.Models
{
    public class Car : BaseDeletableModel<int>
    {
        [Required]
        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }
        
        [Required]
        public int CarBodyTypeId { get; set; }

        public virtual CarBodyType CarBodyType { get; set; }

        [Required]
        public bool IsDiesel { get; set; }

        [Required]
        [Range(1000, 6000)]
        public int EngineCC { get; set; }

        [Required]
        [Range(50, 1000)]
        public int HorsePower { get; set; }

        [Required]
        public bool IsRWD { get; set; }

        [Required]
        public CarColor Color { get; set; }
        
        [Range(0, maximum: double.MaxValue)]
        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsForSale { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
 