using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.App.Core.Data.Repositories;
using LMS.App.Common.Enums;
using System.Data.Entity;
using System.Web.Security;
using LMS.App.Common.Helpers;

namespace LMS.App.Core.Data.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly LMSContext _db;

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public UserRepository()
        {
            _db = new LMSContext();
        }

        public int AddUser(User user, short roleId)
        {
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
            //if (user.UserId > 0)
            //{
            //    UpdateUser(user);
            //}
            var newuser = _db.Entry(user3).State = EntityState.Added;
            //_db.UserRoles.Add(new UserRole { UserId = newuser.UserId, RoleId = roleId });
            return _db.SaveChanges();
        }

        public int AddUser(User user)
        {
            var user3 = new User()
            {
                CountryId = 2,
                CompanyId = 2,
                UserName = "trainee2",
                UserEmailAddress = "trainee2@trainee.com",
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
                Password = PasswordHelper.GetMd5Hash("123456")
               
            };
            user3.Roles.Add(
                       new Role
                       {
                           RoleId = 4,
                           RoleName = "Trainee",
                           RoleDescription = "Trainee"
                       });
                    
            //if (user.UserId > 0)
            //{
            //    UpdateUser(user);
            //}
            var newuser = _db.Entry(user3).State = EntityState.Added;
           return _db.SaveChanges();

        }

      
        public User GetUser(string userName)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserName == userName);
            return user;

        }
        public User GetUser(string userName, string password)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public User GetUserById(int id)
        {
            return _db.Users.Where(x => x.UserId == id).FirstOrDefault();
        }

        public List<User> GetUsers()
        {
            //totalRecords = 10;
            return _db.Users.Where(x => x.UserId > 1).ToList();
        }

        public int UpdateGoals(Qualification obj)
        {
           
            _db.Entry(obj).State = EntityState.Modified;
            return _db.SaveChanges();
        }


        public int UpdateUser(User user)
        {
            var dbuser = _db.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            if (dbuser != null)
            {
                _db.Entry(user).State = EntityState.Modified;
            }
            //foreach (var item in user.Roles)
            //{
            //    var roleEntry = user.Roles.Select(x=>x.RoleId==user.).SingleOrDefault(r => r.RoleId == user.UserId);
            //    if (roleEntry != null)
            //    {
            //        _db.UserRoles.Remove(roleEntry);
            //        _db.SaveChanges();
            //    }
            //    _db.UserRoles.Add(item);
            return _db.SaveChanges();

        }



        //this is from Admin Profile edit
        public int UpdateUser(User user, UserRole userRole)
        {
            var dbuser = _db.Users.Where(u => u.UserId == user.UserId).FirstOrDefault();
            if (dbuser != null)
            {
                dbuser.UserName = user.UserName;
                dbuser.UserEmailAddress = user.UserEmailAddress;
                dbuser.IsDeleted = user.IsDeleted;
                dbuser.Password = user.Password;
                dbuser.UserDetails.FullName = user.UserDetails.FullName;
                dbuser.UserDetails.Designation = user.UserDetails.Designation;
            }
            else
            {
                var newuser = _db.Users.Add(user);
                userRole.UserId = newuser.UserId;

            }

            //var roleEntry = _db.UserRoles.Where(u => u.UserId == user.UserId).FirstOrDefault();
            //if (roleEntry != null)
            //{
            //    _db.UserRoles.Remove(roleEntry);
            //}
            //_db.UserRoles.Add(userRole);

            return _db.SaveChanges();

        }
      

    }
}

