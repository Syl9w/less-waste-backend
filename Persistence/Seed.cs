using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext dbContext, UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any() && !dbContext.WasteReports.Any())
            {
                var users = new List<AppUser>
                {
                    new AppUser{DisplayName="Sultan", UserName="sultan", Email="sultan@test.com", Age=22},
                    new AppUser{DisplayName="Greta Thunberg", UserName="gretat", Email="gretat@test.com", Age=20},
                    new AppUser{DisplayName="Alessandro Vitale", UserName="ales", Email="ales@test.com", Age=33},
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "P@$$w0rd");
                }

                var wasteReports = new List<WasteReport>{
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow,
                        Plastic = 100,
                        Paper = 200,
                        Water = 12,
                        Fuel = 1,
                        Food = 400,
                    },
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow.AddDays(-1),
                        Plastic = 150,
                        Paper = 50,
                        Water = 15,
                        Fuel = 0,
                        Food = 0,
                    },
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow.AddDays(-2),
                        Plastic = 50,
                        Paper = 0,
                        Water = 4,
                        Fuel = 1,
                        Food = 400,
                    },
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow.AddDays(-3),
                        Plastic = 230,
                        Paper = 150,
                        Water = 30,
                        Fuel = 2,
                        Food = 500,
                    },
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow.AddDays(-4),
                        Plastic = 150,
                        Paper = 190,
                        Water = 20,
                        Fuel = 0,
                        Food = 300,
                    }
                };

                await dbContext.WasteReports.AddRangeAsync(wasteReports);

                var wasteGoals = new List<WasteGoal>()
                {
                    new WasteGoal
                    {
                        AppUser = users[0],
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddMonths(1),
                        TargetPlastic = 10,
                        TargetPaper = 10,
                        TargetWater = 10,
                        TargetFood = 10,
                        TargetFuel = 10,
                        ProgressPlastic = 5,
                        ProgressPaper = 5,
                        ProgressWater = 5,
                        ProgressFood = 5,
                        ProgressFuel = 5
                    },
                    new WasteGoal
                    {
                        AppUser = users[1],
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(7),
                        TargetPlastic = 20,
                        TargetPaper = 20,
                        TargetWater = 20,
                        TargetFood = 20,
                        TargetFuel = 20,
                        ProgressPlastic = 10,
                        ProgressPaper = 10,
                        ProgressWater = 10,
                        ProgressFood = 10,
                        ProgressFuel = 10
                    },
                    new WasteGoal { 
                        AppUser = users[2], 
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.UtcNow.AddDays(7),
                        TargetPlastic = 30, 
                        TargetPaper = 30, 
                        TargetWater = 30, 
                        TargetFood = 30, 
                        TargetFuel = 30, 
                        ProgressPlastic = 15, 
                        ProgressPaper = 15, 
                        ProgressWater = 15, 
                        ProgressFood = 15, 
                        ProgressFuel = 15
                    }
                };

                await dbContext.WasteGoals.AddRangeAsync(wasteGoals);

                await dbContext.SaveChangesAsync();

            }
        }
    }
}