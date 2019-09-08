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
                var courses = new List<Course>();
                var qualifications = new List<Qualification>();
                for (int i = 1; i < 10; i++)
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
                    courses.Add(new Course
                    {
                        CourseName = "Blue course" + i,
                        Duration = "2",
                        CourseCode = "BC" + i,
                        Status = true,
                        PreRequsiteCourseId = i
                    });
                    qualifications.Add(new Qualification
                    {
                        QualificationId = i,
                        QualificationCode = "BC-110",
                        QualificationName = "Blue Code course",
                        FontColorCardId = 1,
                        ColorId = 1,
                        Courses = new List<Course> { new Course
                    {
                        CourseName = "Blue course" + i,
                        Duration = "2",
                        CourseCode = "BC" + i,
                        Status = true,
                        PreRequsiteCourseId = i
                    }
                        }
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
                            RoleName = "Coordinator",
                            RoleDescription = "Coordinator"
                        },
                        new Role {
                            RoleId = 3,
                            RoleName = "Trainer",
                            RoleDescription = "Trainer"
                        }
                    };
                //base tables 
                context.Countries.AddRange(countries);
                context.Companies.AddRange(companies);
                context.Roles.AddRange(roles);
                context.Courses.AddRange(courses);
                context.Qualifications.AddRange(qualifications);
                context.SaveChanges();
                //base tables end
                var user1 = new User()
                {
                    CountryId = 1,
                    CompanyId = 1,
                    UserName = "admin",
                    UserEmailAddress = "admin@dmin.com",
                    UserDetails = new UserDetails
                    {
                        FullName = "admin Name",
                        Address = "addres",
                        ContactNo = "conta",
                        EmergencyContactNo = "EmergencyContactNo",
                        Designation = "Designaton",
                        EmployeeId = "EMP001",
                    },
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),

                };
                var user2 = new User()
                {
                    CountryId = 1,
                    CompanyId = 2,
                    UserName = "trainer",
                    UserEmailAddress = "trainer@trainer.com",
                    UserDetails = new UserDetails
                    {
                        FullName = "trainer Name",
                        Address = "addres",
                        ContactNo = "conta",
                        EmergencyContactNo = "EmergencyContactNo",
                        Designation = "Designaton",
                        EmployeeId = "EMP001"
                    },
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),

                };
                var user3 = new User()
                {
                    CountryId = 2,
                    CompanyId = 2,
                    UserName = "trainee",
                    UserEmailAddress = "trainee@trainee.com",
                    UserDetails = new UserDetails
                    {
                        FullName = "trainee Name",
                        Address = "addres",
                        ContactNo = "conta",
                        EmergencyContactNo = "EmergencyContactNo",
                        Designation = "Designaton",
                        EmployeeId = "EMP001"
                    },
                    IsDeleted = false,
                    ActivationCode = Guid.NewGuid(),
                    Password = PasswordHelper.GetMd5Hash("123456"),
                    Roles = new List<Role> {
                       new Role {
                            RoleId = 4,
                            RoleName = "Trainee",
                            RoleDescription = "Trainer"
                        }
                    }
                };
                user1.Roles = roles;
                context.Users.Add(user1);
                user2.Roles = new List<Role> { new Role { RoleId = 4, RoleDescription = "Trainee", RoleName = "Trainee" } };
                context.Users.Add(user2);
                context.SaveChanges();
               // context.CourseQualification.Add(new CourseQualification() { CourseId = 1, QualificationId = 3 });
                //Roles.AddUserToRole("admin", "Trainer");
                user2.Qualifications = qualifications;
                user3.Qualifications = qualifications;
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
