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
    internal class OrganizationSeed : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasData(
                new Organization { Id = 1, Org_Name = "TetraPak" },
                new Organization { Id = 2, Org_Name = "Aarhus University" },
                new Organization { Id = 3, Org_Name = "Municipality" }
                );
        }
    }
}
