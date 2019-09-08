using LMS.App.Common;
using LMS.App.Core.Data.Contexts;
using LMS.App.Core.Data.Repositories;
using System;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Security;

namespace LMS.App.Infrastructure.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IRoleRepository _roleRepository;
        public CustomRoleProvider()
        {
        }

        public CustomRoleProvider(IRoleRepository roleRepository)
        {
            _roleRepository = new RoleRepository();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            using (var LMSContext = new LMSContext())
            {
                var user = LMSContext.Users.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return false;
                return user.Roles != null && user.Roles.Any(r => r.RoleName == roleName);
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            using (var LMSContext = new LMSContext())
            {
                var user = LMSContext.Users.SingleOrDefault(u => u.UserName == username);
                if (user == null)
                    return new string[]{};
                return user.Roles == null ? new string[] { } : user.Roles.Select(u => u.RoleName).ToArray();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return _roleRepository.GetRoles().Any(x => x.RoleName == roleName);
        }

        public override void AddUsersToRoles(string[] usernames, string[] rolenames)
        {
            foreach (string rolename in rolenames)
            {
                if (rolename == null || rolename == "")
                    throw new ProviderException("Role name cannot be empty or null.");
                Log.Error("Role name cannot be empty or null");
                if (!RoleExists(rolename))
                    throw new ProviderException("Role name not found.");

            }
            foreach (string username in usernames)
            {
                if (username == null || username == "")
                    throw new ProviderException("User name cannot be empty or null.");
                if (username.Contains(","))
                    throw new ArgumentException("User names cannot contain commas.");

                foreach (string rolename in rolenames)
                {
                    if (IsUserInRole(username, rolename))
                        throw new ProviderException("User is already in role.");
                }
            }
            try
            {
                foreach (string username in usernames)
                {
                    foreach (string rolename in rolenames)
                    {
                     
                    }
                }
            }
            catch (Exception ex )
            {
                Log.Error(ex.Message);
                // Handle exception.
            }
            finally
            {
                _roleRepository.Dispose();
            }

        }
        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            using (var LMSContext = new LMSContext())
            {
                return LMSContext.Roles.Select(r => r.RoleName).ToArray();
            }
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get; set; }
    }
}