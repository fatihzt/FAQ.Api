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
    public class AnswerManager : IAnswerService
    {
        private readonly IAnswerDal _answerDal;
        public AnswerManager(IAnswerDal answerDal)
        {
            _answerDal = answerDal;
        }

        public int Add(Answer entity)
        {
            return _answerDal.Add(entity);
        }

        public bool Delete(Answer entity)
        {
            return _answerDal.Delete(entity);
        }

        public Answer Get(Expression<Func<Answer, bool>> filter = null)
        {
            return _answerDal.Get(filter);
        }

        /*public List<Answer> GetAll(Expression<Func<Answer, bool>> filter = null)
        {
            return _answerDal.GetAll(filter);
        }*/

        public List<Answer> GetAll(Expression<Func<Answer, bool>> filter = null, Func<IQueryable<Answer>, IIncludableQueryable<Answer, object>> includesPath = null)
        {
            return _answerDal.GetAll(filter, includesPath);
        }

        public bool Update(Answer entity)
        {
            return _answerDal.Update(entity);
        }
    }
}
