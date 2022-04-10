using Layer.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ContextDb _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ContextDb context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); //_dbset object katmanlı mimarideki eğitimde
        }
        public int Delete(T entity)
        {
            _dbSet.Remove(entity);
            return _context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return _dbSet.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _dbSet.Find(id);
        }

        public int Insert(T entity)
        {
            _dbSet.Add(entity);
            return _context.SaveChanges();
        }

        public List<T> List()
        {
            return _dbSet.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filtrele)
        {
            return _dbSet.Where(filtrele).ToList();
        }

        public int Update(T entity)
        {
            return _context.SaveChanges();
        }
    }
}
