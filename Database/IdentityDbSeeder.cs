using BmesRestApi.Models.Shared;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BmesRestApi.Database
{
    public class IdentityDbSeeder
    {
        public static void Seed(BmesIdentityDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        { 
         // Create default User (if there are none)
         //if(!dbContext.Users.Any())
         //   {
         //       CreateUsers(dbContext, roleManager, userManager)
         //           .GetAwaiter()
         //           .GetResult();
         //   }
        }

        private static async Task CreateUsers(BmesIdentityDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<User> userManager)
        {
           //Create Roles (if they doesn't exist yet)
           if(!await roleManager.RoleExistsAsync(UserRole.Administrator.ToString()))
           {
                await roleManager.CreateAsync(new IdentityRole(UserRole.Administrator.ToString()));
           }
            if (!await roleManager.RoleExistsAsync(UserRole.RegisteredUser.ToString()))
            {
                await roleManager.CreateAsync(new IdentityRole(UserRole.RegisteredUser.ToString()));
            }
            //create the Admin user account
            var userAdmin = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Biniam Yemane",
                UserName = "admin@Yahoo.com",
                Email = "admin@Yahoo.com"
            };
            // add Admin to Database and assing a role
            if (await userManager.FindByNameAsync(userAdmin.UserName) == null)
            {
                await userManager.CreateAsync(userAdmin, password: "0000");
                await userManager.AddToRoleAsync(userAdmin, UserRole.Administrator.ToString());
                await userManager.AddToRoleAsync(userAdmin, UserRole.RegisteredUser.ToString());
                //Remove Lockout and E-Mail confirmation
                userAdmin.EmailConfirmed = true;
                userAdmin.LockoutEnabled = false;
            }
            await dbContext.SaveChangesAsync();

        }
    }
}
