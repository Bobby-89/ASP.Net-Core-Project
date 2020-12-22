namespace BMWCarsAndParts.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using BMWCarsAndParts.Data.Common.Models;

    public class PartType : BaseDeletableModel<int>
    {
        [Required]
        public string Name { get; set; }
    }
}
