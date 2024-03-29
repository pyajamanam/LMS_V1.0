namespace LMS.App.Core.Data.Migrations
{
    using LMS.App.Common.Helpers;
    using LMS.App.Core.Data.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DropCreateDatabaseIfModelChanges<LMS.App.Core.Data.Contexts.LMSContext>
    {
        //public Configuration()
        //{
        //    AutomaticMigrationsEnabled = true;
        //}

        protected override void Seed(LMS.App.Core.Data.Contexts.LMSContext context)
        {

            var countries = new List<Country>();
            var companies = new List<Company>();
            for (int i = 0; i < 10; i++)
            {
                countries.Add(new Country
                {
                    CountryName = "CountryName" + i,
                    IsDeleted = false
                });
                companies.Add(new Company()
                {
                    Address = "address" + i,
                    CompanyName = "CompanyName" + i,
                    Remark = "Remarks"
                });
            }
            var roles = new List<Role> {
                    new Role {
                        RoleId = 1,
                        RoleName = "Admin",
                        RoleDescription = "Descriptopn"
                    },
                    new Role {
                        RoleId = 2,
                        RoleName = "Cordinator",
                        RoleDescription ="RoleDescription"
                    },
                    new Role {
                        RoleId = 3,
                        RoleName = "Trainee",
                        RoleDescription= "RoleDescription"
                    },
                     new Role {
                        RoleId = 4,
                        RoleName = "Trainer",
                        RoleDescription= "Trainer"
                    }

                };
            foreach (var item in roles)
            {
                context.Roles.Add(item);
            }
           
            //base tables 
            context.Countries.AddRange(countries);
            context.Companies.AddRange(companies);
            context.Roles.AddRange(roles);
            //base tables end
            //context.Users.Add(user);
            context.SaveChanges();

            //Database.SetInitializer(new LMSInitializer());
        }
    }
}
