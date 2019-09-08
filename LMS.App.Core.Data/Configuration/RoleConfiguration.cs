using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class RoleConfiguration: EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            Property(p => p.RoleId).IsRequired();
            Property(p => p.RoleName).IsRequired();
            Property(p => p.RoleDescription).IsOptional();
            //this.HasMany(x => x.Users)
            //    .WithMany(x => x.Roles)
            //    .Map(t =>
            //    {
            //        t.MapRightKey("UserId");
            //        t.MapLeftKey("RoleId");
            //        t.ToTable("RolesUsers");
            //    });

        }
        
    }
}
