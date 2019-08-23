using LMS.App.Common;
using LMS.App.Common.Enums;
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
                var courses = new List<Course> { new Course { CourseId = 1, CourseName = "Blue course", Venue = "cLASROOM" } };
                var courseEnrolement = new List<CourseEnrollment>
                {
                    new CourseEnrollment {
                        UserId = 1,
                        TrainerId = 1,
                        CourseId =1
                    }
                };
                var qualifications = new List<Qualification> {
                    new Qualification {
                        QualificationCode ="BC-110",
                        Courses = courses,
                        QualificationName = "Blue Code course",
                        FortColorCardId = 1,
                        ColorId =1
                        //ColorId = 1,
                        //FortColorCardId =1,
                } };
                var users = new List<User>{
                    new User()
                {
                    CountryId = 1,
                    CompanyId = 1,
                    UserName = "admin",
                    UserEmailAddress = "admin@dmin.com",
                    UserDetails =  new UserDetails{
                        FullName = "admin Name",
                        Address ="addres",ContactNo="conta",
                        EmergencyContactNo ="EmergencyContactNo",
                        Designation ="Designaton",EmployeeId = "EMP001"
                    },
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
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
                        },
                        new Role {
                            RoleId = 3,
                            RoleName = "Trainer",
                            RoleDescription = "Trainer"
                        }

                    },Qualifications = qualifications,
                    CourseEnrollments = courseEnrolement

                },
                    new User()
                {
                    CountryId = 1,
                    CompanyId = 1,
                    UserName = "admin",
                    UserEmailAddress = "trainer@trainer.com",
                    UserDetails =  new UserDetails{
                        FullName = "trainer Name",
                        Address ="addres",ContactNo="conta",
                        EmergencyContactNo ="EmergencyContactNo",
                        Designation ="Designaton",EmployeeId = "EMP001"
                    },
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
                    Roles = new List<Role> {
                       new Role {
                            RoleId = 3,
                            RoleName = "Trainer",
                            RoleDescription = "Trainer"
                        }
                    },Qualifications = qualifications,
                    CourseEnrollments = courseEnrolement

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
