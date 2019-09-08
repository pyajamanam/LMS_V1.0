using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            Property(c => c.CountryName).IsOptional();
            Property(c => c.IsDeleted).IsRequired();
            //Property(c => c.CreatedDate).HasColumnType("datetime2");
        }
    }
}
