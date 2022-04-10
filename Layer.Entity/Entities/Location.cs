using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Entities
{
    public class Location : BaseEntity
    {
        public string? Loc_Name { get; set; }
        public ICollection<Devices> Devices { get; set; }
    }
}
