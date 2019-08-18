using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class CityConfiguration:EntityTypeConfiguration<City>
    {
        public CityConfiguration()
        {
            Property(c => c.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
        }
    }
}
