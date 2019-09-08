using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(c => c.CourseId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired();
            Property(c => c.CourseName).IsRequired();
            Property(c => c.CourseCode).IsRequired();
            this.HasKey(c => c.CourseId);
            Property(c => c.Status).IsOptional();
        }
    }

}