using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.data.Configuraitons
{
    class DutyConfiguration : IEntityTypeConfiguration<Duty>
    {
        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.Header).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.StartDate).IsRequired();
            builder.Property(x => x.DueDate).IsRequired();
        }
    }
}
