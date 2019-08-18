using LMS.App.Common;
using LMS.App.Common.Helpers;
using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace LMS.App.Core.Data
{
    public class LMSInitializer : DropCreateDatabaseIfModelChanges<LMSContext>
    {
        protected override void Seed(LMSContext context)
        {
            try
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

                var courses = new List<Course> { new Course { CourseId = 1, CourseName = "cn", Venue = "indoor" } };
                var users = new List<User>{
                    new User()
                {
                    UserEmailAddress = "admin@dmin.com",
                    FullName = "admin Name",
                    UserName = "admin",
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
                    CompanyId = 1,
                    CountryId = 1,
                    Roles = new List<Role> {
                        new Role {
                            RoleId = 1,
                            RoleName = "Admin",
                            RoleDescription = "Descriptopn"
                        },
                        new Role {
                            RoleId = 2,
                            RoleName = "Coordinator",
                            RoleDescription = "Coordinator"
                        }
                    },
                   Courses = new List<Course>{ new Course { CourseId = 1,CourseName="cn",Venue="indoor" } }  

                },
                    new User()
                {
                    UserEmailAddress = "trainer@trainer.com",
                    FullName = "trainer trainer",
                    UserName = "trainer",
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
                    CompanyId = 2,
                    CountryId = 2,
                    Roles = new List<Role> {
                        new Role {
                            RoleId = 3,
                            RoleName = "Trainer",
                            RoleDescription = "Trainer"
                        }
                    },
                   Courses = new List<Course>{ new Course { CourseId = 2,CourseName="cn2",Venue="indoor2" } }


                },
                    new User()
                {
                    UserEmailAddress = "trainee@trainer.com",
                    FullName = "trainee trainee",
                    UserName = "trainee",
                    Designation = "trainee",
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
                    CompanyId = 2,
                    CountryId = 2,
                    Roles = new List<Role> {
                        new Role {
                            RoleId = 4,
                            RoleName = "trainee",
                            RoleDescription = "trainee"
                        }
                    },
                   Courses = new List<Course>{ new Course { CourseId = 3,CourseName="cn3",Venue="indoor3" } }


                }
                };
                //base tables 
                context.Countries.AddRange(countries);
                context.Companies.AddRange(companies);
                //base tables end
                context.Users.AddRange(users);
                context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Log.Error("error in migrations");
                //throw;
            }
            base.Seed(context);
        }
    }
}
