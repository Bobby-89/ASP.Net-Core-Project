using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;

namespace BMWCarsAndParts.Data.Models
{
    public class PartType : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
