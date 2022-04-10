using Layer.DataAccess.Abstract;
using Layer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class UserManager
    {
        private readonly IGenericRepository<Users> _repo;

        public UserManager(IGenericRepository<Users> repo)
        {
            _repo = repo;
        }
        public List<Users> GettAll()
        {
            return _repo.List();
        }
        public Users GetAdmin()
        {
            return _repo.Find(x=>x.IsAdmin==true);
        }
        public Users GetUser()
        {
            return _repo.Find(x => x.IsAdmin == false);
        }
    }
}
