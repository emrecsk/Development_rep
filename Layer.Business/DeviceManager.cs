using Layer.DataAccess.Abstract;
using Layer.DataAccess.Concrete;
using Layer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class DeviceManager
    {
        private readonly IGenericRepository<Devices> _repository;

        public DeviceManager(IGenericRepository<Devices> repository)
        {
            _repository = repository;
        }

        public List<Devices> GettAll()
        {
            return _repository.List();
        }
        public Devices FindDevice(int id)
        {
            return _repository.Find(x=> x.Id == id);
        }
        public int DeleteDevice(int id)
        {
            Devices device = _repository.Find(x=> x.Id == id);
            return _repository.Delete(device);
        }
        public int updateDevice(Devices p)
        {
            Devices devices = _repository.Find(x=> x.Id == p.Id);
            devices.Device_Name = p.Device_Name;
            devices.IsActive = p.IsActive;
            devices.OrganizationId = p.OrganizationId;
            devices.LocationId = p.LocationId;
            devices.TypesId = p.TypesId;
            return _repository.Update(devices);
        }
        public int AddDevice (Devices p)
        {
            return _repository.Insert(p);
        }
    }
}
