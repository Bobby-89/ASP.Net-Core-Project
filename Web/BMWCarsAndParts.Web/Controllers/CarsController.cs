namespace BMWCarsAndParts.Web.Controllers
{
    using System.Threading.Tasks;

    using BMWCarsAndParts.Services.Data;
    using BMWCarsAndParts.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly IBodyTypesService bodyTypesService;
        private readonly ICarModelsService carModelsService;
        private readonly ICarsService carsService;

        public CarsController(IBodyTypesService bodyTypesService, ICarModelsService carModelsService, ICarsService carsService)
        {
            this.bodyTypesService = bodyTypesService;
            this.carModelsService = carModelsService;
            this.carsService = carsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateCarInputModel
            {
                BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs(),
                ModelTypes = this.carModelsService.GetAllAsKeyValuePairs(),
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.ModelTypes = this.carModelsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            await this.carsService.CreateAsync(input);

            // TODO: redirect to car info page
            return this.Redirect("/");
        }
    }
}
