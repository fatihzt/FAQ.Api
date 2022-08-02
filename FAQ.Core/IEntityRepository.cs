using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Core
{
    public interface IEntityRepository<T> where T : class
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null, Func<IQueryable<T>, IIncludableQueryable<T, object>> includesPath = null);
        T Get(Expression<Func<T, bool>> filter = null);
        int Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
