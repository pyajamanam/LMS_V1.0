using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CourseQualificationConfiguration : EntityTypeConfiguration<CourseQualification>
    {
        public CourseQualificationConfiguration()
        {

            Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(c => c.QualificationId).IsRequired();
            Property(c => c.CourseId).IsRequired();
            this.HasKey(c => new { c.CourseId,c.QualificationId});
            //this.HasMany(c => c.Courses).WithOptional();
        }
    }
}
