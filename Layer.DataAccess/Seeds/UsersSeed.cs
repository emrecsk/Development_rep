using Layer.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Seeds
{
    internal class UsersSeed : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(
                new Users { Id = 1, Name = "User 1", IsAdmin = true, OrganizationId = 1 },
                new Users { Id = 2, Name = "User 2", IsAdmin = false, OrganizationId = 2 },
                new Users { Id = 3, Name = "User 3", IsAdmin = false, OrganizationId = 3 }
            );
        }
    }
}
