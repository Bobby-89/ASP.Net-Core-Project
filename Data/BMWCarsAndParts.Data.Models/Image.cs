using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BMWCarsAndParts.Data.Common.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BMWCarsAndParts.Data.Models
{
    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        [Required]
        public string Extension { get; set; }
    }
}
