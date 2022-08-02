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
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;
        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public int Add(Question entity)
        {
           return _questionDal.Add(entity);
        }

        public bool Delete(Question entity)
        {
            return _questionDal.Delete(entity);
        }

        public Question Get(Expression<Func<Question, bool>> filter = null)
        {
            return _questionDal.Get(filter);
        }

        /*public List<Question> GetAll(Expression<Func<Question, bool>> filter = null)
        {
            return _questionDal.GetAll(filter);
        }*/

        public List<Question> GetAll(Expression<Func<Question, bool>> filter = null, Func<IQueryable<Question>, IIncludableQueryable<Question, object>> includesPath = null)
        {
            var query = _questionDal.GetAll(filter,includesPath);
            return query.ToList();
        }

        public bool Update(Question entity)
        {
            return _questionDal.Update(entity);
        }
    }
}
