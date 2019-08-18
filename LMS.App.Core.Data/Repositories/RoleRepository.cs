using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using LMS.App.Core.Data.Repositories;

namespace LMS.App.Core.Data.Repositories
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private readonly LMSContext _db;

        private readonly bool _disposed = false;

        public RoleRepository()
        {
            _db = new LMSContext();
        }

        public bool CheckRoleExists(string rolename)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Role> GetRoles()
        {
            return _db.Roles.ToList();
        }

        public Role GetRolesbyUserId(int id)
        {
          return  _db.Users.Select(x=>x.Roles.FirstOrDefault()).FirstOrDefault();
        }

        public string[] GetRolesforUser(string username)
        {
            return new string[]{ };
        }

        public User GetUser(string userName)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserName == userName);
                return user;
           
        }

        public List<User> GetUsers()
        {
            //totalRecords = 10;
           return _db.Users.Where(x => x.UserId > 1).ToList();
        }
    }
}

