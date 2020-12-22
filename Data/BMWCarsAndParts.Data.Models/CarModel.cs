namespace BMWCarsAndParts.Data.Models
{

    using BMWCarsAndParts.Data.Common.Models;

    public class CarModel : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
