using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.App.Core.Data.Repositories;
using LMS.App.Common.Enums;
using System.Data.Entity;
using System.Web.Security;

namespace LMS.App.Core.Data.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private readonly LMSContext _db;

        private readonly bool _disposed = false;

        public UserRepository()
        {
            _db = new LMSContext();
        }

        public int AddUser(User user, short roleId)
        {
            //if (user.UserId > 0)
            //{
            //    UpdateUser(user);
            //}
            //var newuser = _db.Users.Add(user);
            //_db.UserRoles.Add(new UserRole { UserId = newuser.UserId, RoleId = roleId });
            return _db.SaveChanges();
        }

        public int AddUser(User user)
        {
            //if (user.UserId > 0)
            //{
            //    UpdateUser(user);
            //}
            //var newuser = _db.Users.Add(user);
            //_db.UserRoles.Add(new UserRole { UserId = newuser.UserId, RoleId = Convert.ToInt16(UserType.Trainee) });//default user when they register from website
            return _db.SaveChanges();

        }

        public void Dispose()
        {
            throw new NotImplementedException();
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

