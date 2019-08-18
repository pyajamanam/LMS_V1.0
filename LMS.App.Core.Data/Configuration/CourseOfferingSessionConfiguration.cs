using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public  class CourseOfferingSessionConfiguration: EntityTypeConfiguration<CourseOfferingSession>
    {
        public CourseOfferingSessionConfiguration()
        {
            //ToTable("CourseOfferingSession");
        }
    }
}
