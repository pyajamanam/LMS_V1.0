using SchoolManagementSystem.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace SchoolManagementSystem.Data.Configuration
{
    public class PaymentConfiguration:EntityTypeConfiguration<Payment>
    {
        public PaymentConfiguration()
        {
            Property(p => p.PaymentDate).IsOptional();
        }
    }
}
