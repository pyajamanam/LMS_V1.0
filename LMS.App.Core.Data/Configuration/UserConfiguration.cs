using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LMS.Ap.Core.Data.Configuration
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Property(p => p.Id)
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.UserId).IsRequired();
            Property(p => p.UserName).IsRequired();
            Property(p => p.Password).IsRequired();
            this.HasKey(p => p.UserId);
            Property(p => p.UserEmailAddress).IsRequired();
            Map(m =>
            {
                m.ToTable("Users");
            });
            HasRequired(m => m.UserDetails).WithRequiredPrincipal(m => m.User);
           
        }
    }
    public class UserDetailsConfiguration : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsConfiguration()
        {
            Property(p => p.UserDetailsId)
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.UserId).IsRequired();
            Property(p => p.FullName).IsRequired();
            Property(p => p.Address).IsRequired();
            Property(p => p.ContactNo).IsRequired();
            Property(p => p.EmergencyContactNo).IsRequired();
            Property(p => p.Designation).IsRequired();
            Property(p => p.EmployeeId).IsRequired();
            //Map(m =>
            //{
            //    m.ToTable("UsersDetails");
            //});

        }
    }
    


}
