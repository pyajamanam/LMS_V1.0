using System.Data.Entity;
using System.Linq;
using LMS.Ap.Core.Data.Configuration;
using LMS.App.Core.Data.Configuration;
using LMS.App.Core.Data.Entities;
using SchoolManagementSystem.Data.Configuration;

namespace LMS.App.Core.Data.Contexts
{
    public class LMSContext : DbContext
    {

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //  .Map(m =>
            //  {
            //      m.Properties(p => new { p.UserId, p.UserEmailAddress });
            //      m.ToTable("Users");
            //  })
            //  .Map(m =>
            //  {
            //      m.Properties(p => new { p.UserId });
            //      m.ToTable("UserRoles");
            //  });
            //modelBuilder.Entity<Role>()
            // .Map(m =>
            // {
            //     m.Properties(p => new { p.RoleId, p.RoleDescription,p.RoleName });
            //     m.ToTable("Roles");
            // })
            // .Map(m =>
            // {
            //     m.Properties(p => new { p.RoleId });
            //     m.ToTable("UserRoles");
            // });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new CompanyConfiguration());
            modelBuilder.Configurations.Add(new CourseEnrollmentConfiguration());
            modelBuilder.Configurations.Add(new CourseConfiguration());
            modelBuilder.Configurations.Add(new QualificationConfiguration());
            //modelBuilder.Configurations.Add(new UserDetailsConfiguration());
            

        }
        public LMSContext() : base("LMS_DemoEntities")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseEnrollment> CourseEnrollments { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }


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

        //public void AddUserRole(UserRole userRole)
        //{
        //    var roleEntry = UserRoles.SingleOrDefault(r => r.UserId == userRole.UserId);
        //    if (roleEntry != null)
        //    {
        //        UserRoles.Remove(roleEntry);
        //        SaveChanges();
        //    }
        //    UserRoles.Add(userRole);
        //    SaveChanges();
        //}
    }
}
