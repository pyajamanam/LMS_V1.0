﻿using System.Data.Entity;
using System.Linq;
using LMS.App.Web.Entities;
using LMS.App.Web.Models;

namespace LMS.App.Web.Contexts
{
    public class UsersContext : DbContext
    {
        public UsersContext() : base("NewDBMVCEntities")
        {
            //Database.SetInitializer<UsersContext>(
            //    new DropCreateDatabaseIfModelChanges<UsersContext>());

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public void AddUser(User user)
        {
            Users.Add(user);
            SaveChanges();
        }

        public User GetUser(string userName)
        {
            var user = Users.SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        public User GetUser(string userName, string password)
        {
            var user = Users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            return user;
        }

        public void AddUserRole(UserRole userRole)
        {
            var roleEntry = UserRoles.SingleOrDefault(r => r.UserId == userRole.UserId);
            if (roleEntry != null)
            {
                UserRoles.Remove(roleEntry);
                SaveChanges();
            }
            UserRoles.Add(userRole);
            SaveChanges();
        }
    }
}
