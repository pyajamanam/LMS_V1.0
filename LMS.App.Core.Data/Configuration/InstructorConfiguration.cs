using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class InstructorConfiguration:EntityTypeConfiguration<Instructor>
    {
        public InstructorConfiguration()
        {
            Map(m =>
            {
                m.ToTable("Instructors");
            });

            HasMany(i => i.Courses)
                .WithMany(c => c.Instructors)
                .Map(cs =>
                {
                    cs.MapLeftKey("InstructorId");
                    cs.MapRightKey("CourseId");
                    cs.ToTable("InstructorCourse");
                });
        }
    }
}
