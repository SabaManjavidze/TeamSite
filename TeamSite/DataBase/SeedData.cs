using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamSite.DataBase;
using TeamSite.Models;
using TeamSite.Models.TeamModels;
using TeamSite.Models.ViewModels;

namespace JP2.Store.Database
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                TeamDbContext dbContext = scope.ServiceProvider.GetRequiredService<TeamDbContext>();
                try
                {
                    dbContext.Database.Migrate();
                }
                catch (Exception ex)
                {
                }

                if (!dbContext.Products.Any())
                {
                    dbContext.Products.AddRange(
                    new Product()
                    {
                        Category = Category.Jersey,
                        Name = "CRISTIANO RONALDO JUVENTUS JERSEY",
                        Price = 120,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A1041132000&iset=0108&iindex=0007&retBlank=1x1&l1lc=0OR203&l1s=4&l1l=R1050173&l2lc=0OF102&l2s=4&l2l=R20748"
                    },
                    new Product()
                    {
                        Category = Category.Jersey,
                        Name = "MANCHESTER CITY 20/21 HOME JERSEY BY PUMA",
                        Price = 100,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A1043138000&iset=0108&iindex=0007&retBlank=1x1"
                    },
                    new Product()
                    {
                        Category = Category.Jersey,
                        Name = "ARSENAL 20/21 HOME JERSEY BY ADIDAS",
                        Price = 100,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A1041122000&iset=0108&iindex=0007&retBlank=1x1"

                    },
                    new Product()
                    {
                        Category = Category.Ball,
                        Name = "adidas Uniforia League Soccer Ball",
                        Price = 25,
                        ImageUrl = "http://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=300&h=300&cmp=100&c=999&img=A1034100000&iset=0100&iindex=0062&retBlank=1x1&bg=f6f6f6"
                    },
                    new Product()
                    {
                        Category = Category.Ball,
                        Name = "Nike Pitch Team Soccer Ball",
                        Price = 30,
                        ImageUrl = "http://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=550&h=550&cmp=100&c=999&img=A1036728000&iset=0100&iindex=0062&retBlank=1x1&bg=f6f6f6"
                    },
                    new Product()
                    {
                        Category = Category.Shoes,
                        Name = "ADIDAS X 19.1 FG CLEATS (SHADOW BEAST PACK)",
                        Price = 70,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A1033808000&iset=0108&iindex=0088&retBlank=1x1"
                    },
                    new Product()
                    {
                        Category = Category.Shoes,
                        Name = "ADIDAS PREDATOR 20.1 LOW CUT FG CLEATS (LOCALITY PACK)",
                        Price = 120,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A1033930000&iset=0108&iindex=0088&retBlank=1x1"
                    },
                    new Product()
                    {
                        Category = Category.Shoes,
                        Name = "MIZUNO MORELIA II (MIJ)",
                        Price = 150,
                        ImageUrl = "https://www.imagehandler.net/preview/?istyle=0000&fmt=jpg&w=2000&h=2000&cmp=100&c=999&img=A73618000&iset=0108&iindex=0088&retBlank=1x1"
                    });
                }
                if (!dbContext.TeamMembers.Any())
                {
                    dbContext.TeamMembers.AddRange(
                    new TeamMember()
    {
        Name = "player1",
        JerseyNumber = 01,
        Position = Position.Forward,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player2",
        JerseyNumber = 02,
        Position = Position.Forward,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player3",
        JerseyNumber = 03,
        Position = Position.MidleField,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player4",
        JerseyNumber = 04,
        Position = Position.MidleField,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player5",
        JerseyNumber = 05,
        Position = Position.MidleField,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player6",
        JerseyNumber = 06,
        Position = Position.Defener,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player7",
        JerseyNumber = 07,
        Position = Position.Defener,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "player8",
        JerseyNumber = 08,
        Position = Position.GoalKeeper,
        RoleInTeam = Role.Player,
    },
                    new TeamMember()
    {
        Name = "Coach1",
        RoleInTeam = Role.Coach,
    },
                    new TeamMember()
    {
        Name = "Coach2",
        RoleInTeam = Role.Coach,
    }
                    );
                }
                dbContext.SaveChanges();
            }
        }
    }
}
