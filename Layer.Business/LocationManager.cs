using Layer.DataAccess.Abstract;
using Layer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class LocationManager
    {
        private readonly IGenericRepository<Location> _repository;

        public LocationManager(IGenericRepository<Location> repository)
        {
            _repository = repository;
        }

        public List<Location> GettAll()
        {
            return _repository.List();
        }
        public int AddLocation(Location p)
        {
            return _repository.Insert(p);
        }
        public int DeleteLocation(int id)
        {
            Location location = _repository.Find(x => x.Id == id);
            return _repository.Delete(location);
        }
        public int updateLocation(Location p)
        {
            Location location = _repository.Find(x => x.Id == p.Id);
            location.Loc_Name = p.Loc_Name;
            return _repository.Update(location);
        }
        public Location findLocation(int id)
        {
            return _repository.Find(x => x.Id == id);
        }
    }
}
