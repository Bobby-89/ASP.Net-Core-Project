namespace BMWCarsAndParts.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using BMWCarsAndParts.Data.Common.Models;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class CarModel : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
