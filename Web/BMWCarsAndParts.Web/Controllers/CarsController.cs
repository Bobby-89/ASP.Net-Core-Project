using System;
using Microsoft.AspNetCore.Hosting;

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
        private readonly IWebHostEnvironment environment;

        public CarsController(IBodyTypesService bodyTypesService, ICarModelsService carModelsService, ICarsService carsService, UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            this.bodyTypesService = bodyTypesService;
            this.carModelsService = carModelsService;
            this.carsService = carsService;
            this.userManager = userManager;
            this.environment = environment;
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

            try
            {
                await this.carsService.CreateAsync(input, user.Id, $"{this.environment.WebRootPath}/images");
            }
            catch (Exception ex)
            {
                this.ModelState.AddModelError(string.Empty, ex.Message);
                input.BodyTypes = this.bodyTypesService.GetAllAsKeyValuePairs();
                input.ModelTypes = this.carModelsService.GetAllAsKeyValuePairs();
                return this.View(input);
            }

            // TODO: redirect to car info page
            return this.Redirect("/");
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

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
