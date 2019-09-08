using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LMS.Ap.Core.Data.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            //Property(p => p.Id)
            //   .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.UserId).IsRequired();
            Property(p => p.UserName).IsRequired();
            Property(p => p.Password).IsRequired();
            this.HasKey(p => p.UserId);
            Property(p => p.UserId)
              .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.UserEmailAddress).IsRequired();
            Map(m =>
            {
                m.ToTable("Users");
            });
            this.HasMany(u => u.Roles)
            .WithMany()
            .Map(m =>
            {
                m.ToTable("UserRoles");
                m.MapLeftKey("UserId");
                m.MapRightKey("RoleId");
            });
            this.HasMany(x => x.Qualifications)
                .WithMany(x => x.Users)
                .Map(t =>
                    {
                        t.MapRightKey("QualificationId");
                        t.MapLeftKey("UserId");
                        t.ToTable("QualificationsUsers");
                    });
            this.HasRequired(m => m.UserDetails).WithRequiredPrincipal(m => m.User);

        }
    }
    public class UserDetailsConfiguration : EntityTypeConfiguration<UserDetails>
    {
        public UserDetailsConfiguration()
        {
            Property(p => p.UserDetailsId)
               .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //Property(p => p.UserId).IsRequired();
            Property(p => p.FullName).IsRequired();
            Property(p => p.Address).IsRequired();
            Property(p => p.ContactNo).IsRequired();
            Property(p => p.EmergencyContactNo).IsRequired();
            Property(p => p.Designation).IsRequired();
            Property(p => p.EmployeeId).IsRequired();
            Map(m =>
            {
                m.ToTable("UsersDetails");
            });
            //HasRequired(m => m.User).WithRequiredPrincipal(m => m.UserDetails);
        }
    }



}
