using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreWebApiOrnek.DAL.Concerete.EfCore.Configuration
{
    public class ExpenseMap : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> b)
        {
            b.HasKey(ce => ce.Id);

            b.Property(ce => ce.Id).UseIdentityColumn();

            b.Property(ce => ce.ExpenseDate).HasColumnType("datetime");

            b.Property(ce => ce.Amount).HasColumnType("decimal(12, 2)");

            b.Property(ce => ce.Description).HasColumnType("nvarchar(500)").IsRequired();

            b.Property(ce => ce.IsActive).HasDefaultValue(true);

        }
    }
}
