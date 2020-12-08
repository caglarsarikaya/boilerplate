using lightweight.data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace lightweight.data.Seed
{
    class UserSeed:IEntityTypeConfiguration<User>
    {
        private readonly int[] _ids;

        public UserSeed(int [] ids)
        {
            _ids = ids;

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User { Id = _ids[1], Email = "admin", FullName = "admin full name", Password = "osKBwUxnbbrl/MSTYOAq8w==", Status = true, Role = "Admin" });

            builder.HasData(new User { Id = _ids[2], Email = "user", FullName = "user full name", Password = "osKBwUxnbbrl/MSTYOAq8w==", Status = true, Role = "User" });

        }
    }
}
