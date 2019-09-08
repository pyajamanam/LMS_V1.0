using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class QualificationUserConfiguration : EntityTypeConfiguration<QualificationUser>
    {
        public QualificationUserConfiguration()
        {

            Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(c => c.UserQualificationId).IsRequired();
            Property(c => c.UserId).IsRequired();
            //this.HasKey(c => c.QualificationId);
            //this.HasMany(c => c.Courses).WithOptional();
            Map(x => x.ToTable("UserQualifications"));
        }
    }
}
