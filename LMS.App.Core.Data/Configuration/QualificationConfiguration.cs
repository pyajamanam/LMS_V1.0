using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class QualificationConfiguration : EntityTypeConfiguration<Qualification>
    {
        public QualificationConfiguration()
        {
            Property(c => c.Id)
            .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(c => c.QualificationId).IsRequired();
            Property(c => c.QualificationCode).IsRequired();
            Property(c => c.QualificationName).IsRequired();
            Property(c => c.FontColorCardId).IsRequired();
            Property(c => c.ColorId).IsRequired();
            HasMany(c => c.Users).WithMany(x => x.Qualifications);
            //this.HasKey(c => c.QualificationId);
        }
    }
}
