using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Constants;
using Vijuge.Data.Models;

namespace Vijuge.Data.Seeds
{
    public static class DefaultUsers
    {
        public static async Task SeedSuperAdminAsync(UserManager<UserDbModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            try
            {
                var defaultUser = new UserDbModel()
                {
                    FirstName = "Darko",
                    LastName = "Zvezdanovic",
                    UserName = "dink",
                    Email = "darkoinkzvezdanovic@gmail.com",
                    Active = true,
                    Id = 1
                }; 

                if (userManager.Users.All(u => u.Id != defaultUser.Id))
                {
                    var user = await userManager.FindByEmailAsync(defaultUser.Email);
                    if (user == null)
                    {
                        await userManager.CreateAsync(defaultUser, "Password123!");
                        await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());
                        await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                    }
                    await roleManager.SeedClaimsForAdmin();
                }
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
            }

        }
        private async static Task SeedClaimsForAdmin(this RoleManager<IdentityRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            await roleManager.AddPermissionClaim(adminRole, "Users");
        }

        public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
        {
            var allClaims = await roleManager.GetClaimsAsync(role);
            var allPermissions = Constants.Permissions.GeneratePermissionsForModule(module);
            foreach (var permission in allPermissions)
            {
                if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
                {
                    await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
                }
            }
        }
    }
}
