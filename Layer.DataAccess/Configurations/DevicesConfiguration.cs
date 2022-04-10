using Layer.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DataAccess.Concrete.Configurations
{
    internal class DevicesConfiguration : IEntityTypeConfiguration<Devices>
    {
        public void Configure(EntityTypeBuilder<Devices> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Device_Name).HasMaxLength(256);
            builder.HasOne(x=>x.Location).WithMany(x=>x.Devices).HasForeignKey(x=>x.LocationId);
        }
    }
}
