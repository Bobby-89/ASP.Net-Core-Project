using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;

namespace BMWCarsAndParts.Data.Models
{
    public class Like : BaseDeletableModel<int>
    {
        [Required]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
