namespace Resturant_os.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Resturant_os.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Resturant_os.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Resturant_os.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            /*
            // Create Roles     
            string[] RoleIds = {
                                      "4973A286-A982-4BA2-BB9E-388A399F9DBD"// WAdmin
            };

            string[] RoleNames = {
                                      "Admin"// WAdmin                  
            };

            for (int i = 0; i < RoleIds.Length; i++)
            {
                context.Roles.AddOrUpdate(
                p => p.Id,
                new IdentityRole
                {
                    Id = RoleIds[i],
                    Name = RoleNames[i]
                });
            }

    */

            // Create Resturant  
            int[] ResturantId = {
                                                1,
            };
            string[] ResturantNames = {
                                                "Carrot Crumpz",
            };
            string[] ResturantAddress = {
                                                "Parish Gap",
            };
            string[] ResturantPhoneNo = {
                                                "1-246-555-5452",
            };

            for (int i = 0; i < ResturantNames.Length; i++)
            {
                context.Resturants.AddOrUpdate(
                p => p.ResturantId,
                new Resturant
                {
                    ResturantId = ResturantId[i],
                    ResturantName = ResturantNames[i],
                    Address = ResturantAddress[i],
                    PhoneNo = ResturantPhoneNo[i],
                    Created = DateTime.Now,
                    Updated = DateTime.Now
                });
            }

            //Create Admin User
            if (manager.FindByName("Admin") == null)
            {
                string AdminPassword = "Password1#";
                var admin = new ApplicationUser()
                {
                    UserName = "Admin",
                    Email = "zacx122@gmail.com",
                    EmailConfirmed = true, // TEST  ---- remove when pushing to LIVE
                    PhoneNumber = "1-246-824-5321"
                };

                manager.Create(admin, AdminPassword);
            }


            //Add Roles to KFC User
            //var adminUser = manager.FindByName("Admin");
            //if (manager.IsInRole(adminUser.Id, "Admin") == false) manager.AddToRole(adminUser.Id, "Admin");
        }
    }
}
