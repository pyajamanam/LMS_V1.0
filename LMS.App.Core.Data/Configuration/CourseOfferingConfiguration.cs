using SchoolManagementSystem.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CourseOfferingConfiguration : EntityTypeConfiguration<CourseOffering>
    {
        public CourseOfferingConfiguration()
        {
            Property(c => c.StartDate).HasColumnType("datetime2");
        }
    }
}
