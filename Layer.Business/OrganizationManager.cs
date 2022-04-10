using Layer.DataAccess.Abstract;
using Layer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Business
{
    public class OrganizationManager
    {
        private readonly IGenericRepository<Organization> _repository;

        public OrganizationManager(IGenericRepository<Organization> repository)
        {
            _repository = repository;
        }

        public List<Organization> GettAll()
        {
            return _repository.List();
        }
        public int AddOrganization(Organization p)
        {
            return _repository.Insert(p);
        }
        public int DeleteOrganization(int id)
        {
            Organization organization = _repository.Find(x => x.Id == id);
            return _repository.Delete(organization);
        }
        public int updateOrganization(Organization p)
        {
            Organization organization = _repository.Find(x => x.Id == p.Id);
            organization.Org_Name = p.Org_Name;
            return _repository.Update(organization);
        }
        public Organization findOrganization(int id)
        {
            return _repository.Find(x => x.Id == id);
        }
    }
}
