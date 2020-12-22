namespace BMWCarsAndParts.Web.Controllers
{
    using BMWCarsAndParts.Services.Data;
    using BMWCarsAndParts.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly IBodyTypesService bodyTypesService;
        private readonly ICarModelsService carModelsService;

        public CarsController(IBodyTypesService bodyTypesService, ICarModelsService carModelsService)
        {
            this.bodyTypesService = bodyTypesService;
            this.carModelsService = carModelsService;
        }

        public IActionResult Create()
        {
            var viewModel = new CreateCarInputModel();
            viewModel.BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs();
            viewModel.ModelTypes = this.carModelsService.GetAllAsKeyValuePairs();
            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.ModelTypes = this.carModelsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // TODO: create car using dervice method
            // TODO: redirect to car info page
            return this.Redirect("/");
        }
    }
}
