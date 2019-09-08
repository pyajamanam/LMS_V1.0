using LMS.App.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.App.Core.Data.Configuration
{
    public class CourseScheduleConfiguration : EntityTypeConfiguration<CourseSchedule>
    {
        public CourseScheduleConfiguration()
        {

            Property(p => p.Id).IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(p => p.ReferenceId).IsRequired();
            Property(p => p.CourseName).IsRequired();
            Property(p => p.FromDate).IsRequired();
            Property(p => p.ToDate).IsRequired();
            Property(p => p.Venue).HasMaxLength(300).IsRequired();
            Property(p => p.Venue).HasMaxLength(300).IsRequired();
            Property(p => p.Remarks).IsRequired();
            Map(m =>
          {
              m.ToTable("CourseSchedules");

          });

        }
    }

}
