using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Configuration
{
    public class CourseEnrollmentConfiguration : EntityTypeConfiguration<CourseEnrollment>
    {
        public CourseEnrollmentConfiguration()
        {
            Property(p => p.EnrolmentId).IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            //Property(p => p.Courses).IsOptional();
            //Property(p => p.CourseName).IsRequired();
            //Property(p => p.Venue).IsOptional();
            Property(p => p.TrainerId).HasColumnName("TrainerId").IsOptional();
            Property(p => p.UserId).HasColumnName("RegisterUserId").HasColumnType("int").IsRequired();
            Map(m =>
          {
              m.ToTable("CourseRegistrations");

          });

        }
    }

}
