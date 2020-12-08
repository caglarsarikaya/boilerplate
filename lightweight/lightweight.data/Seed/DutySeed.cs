using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.data.Seed
{
    class DutySeed : IEntityTypeConfiguration<Duty>
    {

        private readonly int[] _ids;

        public DutySeed(int[] ids)
        {
            _ids = ids;

        }

        public void Configure(EntityTypeBuilder<Duty> builder)
        {
            builder.HasData(new Duty
            {
                Id = _ids[1],
                Header = "TO DO List",
                Description = "kullanıcı rolleri olacak,görev atanacak",
                StartDate = new DateTime(2020,01, 01),
                DueDate = new DateTime(2020, 01, 01),
                UserId = _ids[1],
                StatusId = _ids[0]
            });
        }
    }
}
