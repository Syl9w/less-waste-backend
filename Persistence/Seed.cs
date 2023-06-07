using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Identity;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext dbContext, UserManager<AppUser> userManager){
            if(!userManager.Users.Any()){
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
            }
        }
    }
}