using Layer.DataAccess.Abstract;
using Layer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class TypesManager
    {
        private readonly IGenericRepository<Types> _repository;

        public TypesManager(IGenericRepository<Types> repository)
        {
            _repository = repository;
        }

        public List<Types> GettAll()
        {
            return _repository.List();
        }
        public int AddTypes(Types p)
        {
            return _repository.Insert(p);
        }
        public int DeleteTypes(int id)
        {
            Types types = _repository.Find(x => x.Id == id);
            return _repository.Delete(types);
        }
        public int updateTypes(Types p)
        {
            Types types = _repository.Find(x => x.Id == p.Id);
            types.Type_Name = p.Type_Name;
            return _repository.Update(types);
        }
        public Types findTypes(int id)
        {
            return _repository.Find(x => x.Id == id);
        }
    }
}
