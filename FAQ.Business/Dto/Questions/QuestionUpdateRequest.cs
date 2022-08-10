using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Business.Dto.Questions
{
    public class QuestionUpdateRequest
    {
        public int Id { get; set; }
        public string QuestionDetail { get; set; }
        public string AnswerDetail { get; set; }
        public int CategoryId { get; set; }
    }
}
