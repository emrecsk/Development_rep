using Layer.Entity.Entities;

namespace Project_NTT_data.Models
{
    public class DeviceViewModelList
    {
        public List<DeviceViewModel> DeviceList { get; set; }
        public bool IsAdmin { get; set; }
        public List<Types> Types { get; set; }
        public List<Location> Location { get; set; }
        public List<Organization> Organization { get; set; }
    }
}
