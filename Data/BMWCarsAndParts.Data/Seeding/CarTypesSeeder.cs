namespace BMWCarsAndParts.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using BMWCarsAndParts.Data.Models;

    public class CarTypesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.CarBodyTypes.Any())
            {
                return;
            }

            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "Saloon" });
            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "Estate " });
            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "Coupe" });
            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "Cabriolet " });
            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "SUV " });
            await dbContext.CarBodyTypes.AddAsync(new CarBodyType { BodyType = "Van  " });

            await dbContext.SaveChangesAsync();
        }
    }
}
