using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.data.Configuraitons
{
    class DutyStatusesConfiguration : IEntityTypeConfiguration<DutyStatuses>
    {
        public void Configure(EntityTypeBuilder<DutyStatuses> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseSqlServerIdentityColumn();
            builder.Property(x => x.Statue).IsRequired().HasMaxLength(100);
        }

     
    }
}
