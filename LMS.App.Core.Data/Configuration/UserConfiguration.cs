using LMS.App.Core.Data.Entities;
using System.Data.Entity.ModelConfiguration;

namespace LMS.Ap.Core.Data.Configuration
{
    public class UserConfiguration: EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            Map(m =>
            {
                m.ToTable("Users");
            });

        }
    }
}
