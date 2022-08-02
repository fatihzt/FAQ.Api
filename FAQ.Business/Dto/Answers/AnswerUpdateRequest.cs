using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAQ.Business.Dto.Answers
{
    public class AnswerUpdateRequest
    {
        public int Id { get; set; }
        public string Answers { get; set; }
        public int QuestionId { get; set; }
    }
}
