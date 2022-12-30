namespace Project_NTT_data.Models
{
    public class DeviceViewModel
    {
        public string DeviceId { get; set; }

        public bool IsActive { get; set; }
        public string? Device_Name { get; set; }
        public int LocationId { get; set; }
        public string? Loc_Name { get; set; }
        public int TypesId { get; set; }
        public  string TypeName { get; set; }
        public int OrganizationId { get; set; }
        public  string OrganizationName { get; set; }
    }
}
