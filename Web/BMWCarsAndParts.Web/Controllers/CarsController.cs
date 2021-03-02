namespace BMWCarsAndParts.Web.Controllers
{
    using System.Threading.Tasks;

    using BMWCarsAndParts.Data.Models;
    using BMWCarsAndParts.Services.Data;
    using BMWCarsAndParts.Web.ViewModels.Cars;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CarsController : Controller
    {
        private readonly IBodyTypesService bodyTypesService;
        private readonly ICarModelsService carModelsService;
        private readonly ICarsService carsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CarsController(IBodyTypesService bodyTypesService, ICarModelsService carModelsService, ICarsService carsService, UserManager<ApplicationUser> userManager)
        {
            this.bodyTypesService = bodyTypesService;
            this.carModelsService = carModelsService;
            this.carsService = carsService;
            this.userManager = userManager;
        }

        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(CreateCarInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                input.BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.ModelTypes = this.carModelsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            ////var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = await this.userManager.GetUserAsync(this.User);
            await this.carsService.CreateAsync(input, user.Id);

            // TODO: redirect to car info page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            const int ItemsPerPage = 8;
            var viewModel = new CarsListViewModel
            {
                ItemsPerPage = ItemsPerPage,
                PageNumber = id,
                CarsCount = this.carsService.GetCount(),
                Cars = this.carsService.GetAll(id, ItemsPerPage),
            };
            return this.View(viewModel);
        }
    }
}
