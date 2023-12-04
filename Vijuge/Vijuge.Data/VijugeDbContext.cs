using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vijuge.Data.Models;
using Vijuge.Data.Seeds;

namespace Vijuge.Data
{
    public  class VijugeDbContext : IdentityDbContext
    {
        public VijugeDbContext(DbContextOptions<VijugeDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static async Task Seed(UserManager<UserDbModel> userManager, RoleManager<IdentityRole> roleManager)
        {
            await DefaultRoles.SeedAsync(roleManager);
            await DefaultUsers.SeedSuperAdminAsync(userManager, roleManager);
        }

        public DbSet<UserDbModel> Users {  get; set; }
    }
}
