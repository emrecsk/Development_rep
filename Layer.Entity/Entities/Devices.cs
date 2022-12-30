using System.ComponentModel.DataAnnotations.Schema;

namespace Layer.Entity.Entities
{
    public class Devices : BaseEntity
    {
        public bool IsActive { get; set; }
        public string? Device_Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int TypesId { get; set; }
        public virtual Types Types { get; set; }
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        [NotMapped]
        public string CryptedID { get; set; }
    }
}
