using System;
using System.Linq;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.Enums;
using CCN_Solution.ColisDDD.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using NLog.Fluent;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Seeds
{
    public static class DefaultSuperAdmin
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager, Agence agence)
        {
            //Seed Default User
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@gmail.com",
                FirstName = "Mukesh",
                LastName = "Murugan",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                // AgenceId = agence.Id
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    try
                    {
                        await userManager.CreateAsync(defaultUser, "123Pa$$word!");
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => userManager.CreateAsync(defaultUser, \"123Pa$$word!\")");
                    }

                    try
                    {
                        await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => AddToRoleAsync(defaultUser, Roles.Basic.ToString())");
                    }

                    try
                    {
                        await userManager.AddToRoleAsync(defaultUser, Roles.Moderator.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => AddToRoleAsync(defaultUser, Roles.Moderator.ToString())");
                    }

                    try
                    {
                        await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => AddToRoleAsync(defaultUser, Roles.Admin.ToString())");
                    }

                    try
                    {
                        await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
                    }
                    catch (Exception ex)
                    {
                        Log.Warn(ex.Message + ": \n" + ex.InnerException?.Message + ": " + " \nAn error occurred seeding the DB => AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString()");
                    }
                }

            }
        }
    }
}
