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
                        Date = DateTime.UtcNow.AddDays(1),
                        Plastic = 100,
                        Paper = 200,
                        Water = 12,
                        Fuel = 1,
                        Food = 400,
                    },
                    new WasteReport{
                        Reporter = users[0],
                        Date = DateTime.UtcNow,
                        Plastic = 150,
                        Paper = 50,
                        Water = 15,
                        Fuel = 0,
                        Food = 0,
                    },
                    new WasteReport{
                        Reporter = users[1],
                        Date = DateTime.UtcNow.AddDays(1),
                        Plastic = 50,
                        Paper = 0,
                        Water = 4,
                        Fuel = 1,
                        Food = 400,
                    },
                    new WasteReport{
                        Reporter = users[2],
                        Date = DateTime.UtcNow.AddDays(1),
                        Plastic = 230,
                        Paper = 150,
                        Water = 30,
                        Fuel = 2,
                        Food = 500,
                    }
                };

                await dbContext.WasteReports.AddRangeAsync(wasteReports);
                await dbContext.SaveChangesAsync();

            }
        }
    }
}