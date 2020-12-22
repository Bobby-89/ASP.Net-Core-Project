﻿namespace BMWCarsAndParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BMWCarsAndParts.Data.Common.Models;

    public class Workshop : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^([0-9]{10})$")]
        public string MobilePhoneNumber { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        public string ImageId { get; set; }

        public virtual Image Image { get; set; }
    }
}
