using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.Models;
using TeamSite.Models.TeamModels;

namespace TeamSite.DataBase
{
    public class TeamDbContext : IdentityDbContext<User>
    {
        public TeamDbContext(DbContextOptions<TeamDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }

    }
}
