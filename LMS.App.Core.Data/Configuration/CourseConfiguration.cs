using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CompanyConfiguration : EntityTypeConfiguration<Company>
    {
        public CompanyConfiguration()
        {
            Property(c => c.Address).IsOptional();
            Property(c => c.CompanyName).IsRequired();
            Property(c => c.CompanyId).IsRequired();
            Property(c => c.Remark).IsOptional();

        }
    }
}
