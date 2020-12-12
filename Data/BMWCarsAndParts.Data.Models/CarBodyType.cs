using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BMWCarsAndParts.Data.Models
{
    public class CarBodyType : BaseDeletableModel<int>
    {
        [Required]
        public string BodyType { get; set; }
    }
}
