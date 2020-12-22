namespace BMWCarsAndParts.Data.Models
{
    using System;

    using BMWCarsAndParts.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int CarId { get; set; }

        public virtual Car Car { get; set; }

        public string Extension { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }
    }
}
