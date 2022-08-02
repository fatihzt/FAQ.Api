using FAQ.Core.Abstract;
using FAQ.Core.EntityFramework;
using FAQ.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Core.Concrete
{
    public class EfAnswerDal: EfEntityRepositoryBase<Answer, DatabaseContext>, IAnswerDal
    {
    }
}
