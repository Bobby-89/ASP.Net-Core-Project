namespace BMWCarsAndParts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BMWCarsAndParts.Data.Models;

    public class CarModelsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarModels.Any())
            {
                return;
            }

            await dbContext.CarModels.AddAsync(new CarModel { Name = "1 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "2 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "3 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "4 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "5 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "6 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "7 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "8 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X1 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X2 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X3 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X4 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X5 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X6 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "X7 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "Z1 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "Z3 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "Z4 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "Z8 series" });
            await dbContext.CarModels.AddAsync(new CarModel { Name = "M1 series" });

            await dbContext.SaveChangesAsync();
        }
    }
}
