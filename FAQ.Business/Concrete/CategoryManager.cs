using FAQ.Business.Abstract;
using FAQ.Core.Abstract;
using FAQ.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        public bool Delete(Category entity)
        {
            return _categoryDal.Delete(entity);
        }

        public Category Get(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>> includesPath = null)
        {
            return _categoryDal.Get(filter,includesPath);
        }

        /*public List<Category> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }*/

        public List<Category> GetAll(Expression<Func<Category, bool>> filter = null, Func<IQueryable<Category>, IIncludableQueryable<Category, object>> includesPath = null)
        {
            return _categoryDal.GetAll(filter, includesPath);
        }

        public bool Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }
    }
}
