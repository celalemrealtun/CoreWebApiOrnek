using CoreWebApiOrnek.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreWebApiOrnek.DAL.Concerete.EfCore.Configuration
{
    public class GroupMap : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> b)
        {

            b.HasKey(ce => ce.Id);

            b.Property(ce => ce.Id).UseIdentityColumn();
            b.Property(ce => ce.GroupName).HasMaxLength(50).IsRequired();
            b.Property(ce => ce.IsActive).HasDefaultValue(true);

            b.HasMany(ce => ce.Expenses).WithOne(ce => ce.Group).HasForeignKey(ce => ce.GroupId);
        }
    }
}
