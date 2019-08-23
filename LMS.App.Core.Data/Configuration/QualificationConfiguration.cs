using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class QualificationConfiguration : EntityTypeConfiguration<Qualification>
    {
        public QualificationConfiguration()
        {
            Property(c => c.QualificationCode).IsRequired();
            Property(c => c.QualificationName).IsRequired();
            //this.HasKey(c => c.QualificationId);
            this.HasMany(c => c.Courses).WithOptional();
        }
    }
}
