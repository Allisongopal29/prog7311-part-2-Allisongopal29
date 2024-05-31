using Microsoft.AspNetCore.Identity;
using BookShoppingCartMvcUI.Constants;
using System;

namespace BookShoppingCartMvcUI.Data
{
    public class DbSeeder
    {
        public static async Task SeedDefaultData(IServiceProvider service)
        {
            var userMgr = service.GetService<UserManager<IdentityUser>>();
            var roleMgr = service.GetService<RoleManager<IdentityRole>>();
            //adding some roles to db
            await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.Farmer.ToString()));
            await roleMgr.CreateAsync(new IdentityRole(Roles.Employee.ToString()));

            // create admin user

            var admin = new IdentityUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };

            var userInDb = await userMgr.FindByEmailAsync(admin.Email);
            if (userInDb is null)
            {
                await userMgr.CreateAsync(admin, "Admin@123");
                await userMgr.AddToRoleAsync(admin,Roles.Admin.ToString());
            }

            // create farmer user role

            var farmer = new IdentityUser
            {
                UserName = "farmer@gmail.com",
                Email = "farmer@gmail.com",
                EmailConfirmed = true
            };

            var farmerInDb = await userMgr.FindByEmailAsync(farmer.Email);
            if (farmerInDb is null)
            {
                await userMgr.CreateAsync(farmer, "Farmer@123");
                await userMgr.AddToRoleAsync(farmer, Roles.Farmer.ToString());
            }

            // create employee user role

            var employee = new IdentityUser
            {
                UserName = "employee@gmail.com",
                Email = "employee@gmail.com",
                EmailConfirmed = true
            };

            var employeeInDb = await userMgr.FindByEmailAsync(employee.Email);
            if(employeeInDb is null)
            {
                await userMgr.CreateAsync(employee, "Employee@123");
                await userMgr.AddToRoleAsync(employee, Roles.Employee.ToString());
            }


        }
    }
}
