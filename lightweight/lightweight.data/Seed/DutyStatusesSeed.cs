using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.data.Seed
{
    class DutyStatusesSeed : IEntityTypeConfiguration<DutyStatuses>
    {

        private readonly int[] _ids;

        public DutyStatusesSeed(int[] ids)
        {
            _ids = ids;

        }


        public void Configure(EntityTypeBuilder<DutyStatuses> builder)
        {

            builder.HasData(new DutyStatuses { Id = _ids[1], Statue = "Plan" });
            builder.HasData(new DutyStatuses { Id = _ids[2], Statue = "To Do" });
            builder.HasData(new DutyStatuses { Id = _ids[3], Statue = "In Progress" });
            builder.HasData(new DutyStatuses { Id = _ids[4], Statue = "Done" });
            builder.HasData(new DutyStatuses { Id = _ids[5], Statue = "Bug Report" });

        }
    }
}
