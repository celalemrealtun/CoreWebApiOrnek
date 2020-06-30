using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApiOrnek.DAL.Concerete.EfCore.Configuration
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.HasKey(ce => ce.Id);

            b.Property(ce => ce.Id).UseIdentityColumn();
            b.Property(ce => ce.UserName).HasMaxLength(100).IsRequired();
            b.Property(ce => ce.PassWord).HasMaxLength(100).IsRequired();
            b.Property(ce => ce.Name).HasColumnType("nvarchar(150)").IsRequired();
            b.Property(ce => ce.IsAdmin).HasDefaultValue(false);





            b.HasMany(ce => ce.Expenses).WithOne(ce => ce.User).HasForeignKey(ce => ce.UserId);
        }
    }
}
