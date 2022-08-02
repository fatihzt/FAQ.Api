using FAQ.Business.Abstract;
using FAQ.Business.Dto.Questions;
using FAQ.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Apı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _questionService.GetAll(includesPath: path => path.Include(x => x.Category));
            return Ok(result);
        }
        [HttpGet("ByCategoryId/{categoryid}")]
        public IActionResult GetByCategoryId(int categoryid)
        {
            var result = _questionService.GetAll(q => q.CategoryId == categoryid,path=>path.Include(q=>q.Category));
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Question result = _questionService.Get(q => q.Id == id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] QuestionCreateRequest dto)
        {
            Question entity = new() { QuestionDetail = dto.QuestionDetail, CategoryId = dto.CategoryId };
            int result = _questionService.Add(entity);
            return Ok(result > 0 ? "Kayıt başarılı" : "Kayıt başarısız");
        }
        [HttpPut]
        public IActionResult Put([FromBody] QuestionUpdateRequest dto)
        {
            Question entity = new() { Id = dto.Id, QuestionDetail = dto.QuestionDetail, CategoryId = dto.CategoryId };
            bool result = _questionService.Update(entity);
            return Ok(result ? entity : null);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _questionService.Delete(new() { Id = id });
            return Ok(result);
        }
    }
}
