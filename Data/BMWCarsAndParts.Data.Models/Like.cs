namespace BMWCarsAndParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BMWCarsAndParts.Data.Common.Models;

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
