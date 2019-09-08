using LMS.App.Core.Data.Entities;
using System.Collections.Generic;
using System.Web.Security;

namespace LMS.App.Core.Data.Repositories
{
   public interface IUserRepository
    {
      List<User> GetUsers();

        User GetUserById(int id);

        int UpdateGoals(Qualification obj);

        int UpdateUser(User user);
        // List<User> GetUserByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords);

        //  string GetUserNameByEmail(string emailToMatch);

        //List<User> GetUsersByUsername(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords);

        //User GetUserByUsername(string usernameToMatch);

        //User GetUserByCustomerNumber(string customerNumber);

        //User SetUserActivationCode(string username);

        //User ValidateUserActivationCode(Guid activationCode, string customerNumber);
        //// umbraco password uopdate 
        //bool UpdateUserPassword(string username, string oldpassword, string newpassword);
        ////prasant 
        //bool UpdateUserPassword(string username, string newpassword);//this method from front end;

        //bool UnLockUser(string username);

        //bool LockUser(string username);

        //bool DeleteUserByUsername(string username);

        //bool IsUserInGroup(string userame, string groupName);

        int AddUser(User model);

        int UpdateUser(User user,UserRole userRole);

        //string[] GetRoles();

        //IMemberGroup GetById(int id);

        //IMemberGroup GetByName(string id);

        //string[] GetRolesforUser(string username);

        //bool CheckRoleExists(string rolename);

        //bool AddUserGroups(string[] usernames, string[] groupnames);

        //bool DeleteGroupsforUser(string[] groupnames, string[] usernames);

        //int? GetAttemptsCountForUser(string username);

        //void UpdateFailure_SuccessCount(string username, string statusType);

        //int ValidateUserResponseStatus(string userName, string password, string zipcode, CmsUserType userType);

        //bool UpdateUserName(long userId, string newUserName);

        //bool UpdateEmail(string username, string email);

        void Dispose();
        User GetUser(string userName);
        User GetUser(string userName,string password);
    }
}
