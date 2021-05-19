using System;
using System.Threading.Tasks;
using CCN_Solution.ColisDDD.Application.Enums;
using CCN_Solution.ColisDDD.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace CCN_Solution.ColisDDD.Infrastructure.Persistence.Seeds
{
    public static class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<Role> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.SuperAdmin.ToString() });
            await roleManager.CreateAsync(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.Admin.ToString() });
            await roleManager.CreateAsync(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.Moderator.ToString() });
            await roleManager.CreateAsync(new Role { Id = Guid.NewGuid().ToString(), Name = Roles.Basic.ToString() });
        }
    }
}
