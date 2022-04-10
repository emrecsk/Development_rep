using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Entities
{
    public class Types : BaseEntity
    {
        public string? Type_Name { get; set; }
        public ICollection<Devices> Devices { get; set; }
    }
}
