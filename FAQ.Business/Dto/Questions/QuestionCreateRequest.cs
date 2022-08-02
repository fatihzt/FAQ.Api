using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Business.Dto.Questions
{
    public class QuestionCreateRequest
    {
        public string QuestionDetail { get; set; }
        public int CategoryId { get; set; }
    }
}
