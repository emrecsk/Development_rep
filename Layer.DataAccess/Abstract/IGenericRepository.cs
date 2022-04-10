using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Layer.DataAccess.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> List();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
        T GetByID(int id);
        List<T> List(Expression<Func<T, bool>> filtrele);
        T Find(Expression<Func<T, bool>> where);
    }
}
