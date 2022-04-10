using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Entities
{
    public class Organization : BaseEntity
    {
        public string? Org_Name { get; set; }
        public ICollection<Devices> Devices { get; set; }
        public ICollection<Users> Users { get; set; }
    }
}
