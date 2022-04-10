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
    internal class LocationSeed : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location { Id = 1, Loc_Name = "Aarhus" },
                new Location { Id = 2, Loc_Name = "Skanderborg" },
                new Location { Id = 3, Loc_Name = "Odder" }
                );
        }
    }
}
