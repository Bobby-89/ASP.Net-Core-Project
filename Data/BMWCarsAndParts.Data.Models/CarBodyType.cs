namespace BMWCarsAndParts.Data.Models
{
    using BMWCarsAndParts.Data.Common.Models;

    public class CarBodyType : BaseDeletableModel<int>
    {
        public string BodyType { get; set; }
    }
}
