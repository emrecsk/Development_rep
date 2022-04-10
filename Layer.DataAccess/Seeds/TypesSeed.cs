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
    internal class TypesSeed : IEntityTypeConfiguration<Types>
    {
        public void Configure(EntityTypeBuilder<Types> builder)
        {
            builder.HasData(
                new Types { Id = 1, Type_Name ="Camera"},
                new Types { Id = 2, Type_Name ="Sensor"},
                new Types { Id = 3, Type_Name ="Type 3"}
                );
        }
    }
}
