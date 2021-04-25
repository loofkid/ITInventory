using ITInventory.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITInventory
{
    public static class InventoryIdentity
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            foreach (string rollName in Enum.GetNames(typeof(Enums.Roles)))
            {
                await roleManager.CreateAsync(new IdentityRole(rollName));
            }
        }

        public static async Task AddUserToSuperAdmin(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            var user = await userManager.FindByIdAsync(httpContextAccessor.HttpContext.User.Identity.Name);
            await userManager.AddToRoleAsync(user, "SuperAdmin");
        }

    }
}
