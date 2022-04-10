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
    internal class DeviceSeed : IEntityTypeConfiguration<Devices>
    {
        public void Configure(EntityTypeBuilder<Devices> builder)
        {
            builder.HasData(
                new Devices { Id = 1, Device_Name = "Device 1", IsActive = true, LocationId = 1, OrganizationId = 1, TypesId = 1 },
                new Devices { Id = 2, Device_Name = "Device 2", IsActive = true, LocationId = 1, OrganizationId = 1, TypesId = 2 },
                new Devices { Id = 3, Device_Name = "Device 3", IsActive = true, LocationId = 2, OrganizationId = 2, TypesId = 2 },
                new Devices { Id = 4, Device_Name = "Device 4", IsActive = true, LocationId = 3, OrganizationId = 2, TypesId = 3 },
                new Devices { Id = 5, Device_Name = "Device 5", IsActive = true, LocationId = 3, OrganizationId = 3, TypesId = 2 }
                );
        }
    }
}
