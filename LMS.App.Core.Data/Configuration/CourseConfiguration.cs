using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(c => c.CourseId).IsRequired();
            Property(c => c.CourseName).IsRequired();
            this.HasKey(c => c.CourseId);
            Property(c => c.Venue).IsOptional();
            Property(p => p.CourseId).HasColumnName("CourseEnrolmentId").HasColumnType("int").IsRequired();

        }
    }
}
