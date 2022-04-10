using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Entity.Entities
{
    public class Users : BaseEntity
    {
        public string? Name { get; set; }
        public bool IsAdmin { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        
    }
}
