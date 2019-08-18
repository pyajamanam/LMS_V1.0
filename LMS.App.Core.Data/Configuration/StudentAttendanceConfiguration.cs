using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class StudentAttendanceConfiguration:EntityTypeConfiguration<Attendance>
    {
        public StudentAttendanceConfiguration()
        {
            ToTable("StudentAttendance");
        }
    }
}
