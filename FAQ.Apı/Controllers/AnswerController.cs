using FAQ.Business.Abstract;
using FAQ.Business.Dto;
using FAQ.Business.Dto.Answers;
using FAQ.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FAQ.Apı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var value = _answerService.GetAll( includesPath:path=>path.Include(a=>a.Question).ThenInclude(q=>q.Category));
            //var value = _answerService.GetAll();
            return Ok(value);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Answer result=_answerService.Get(a => a.Id == id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody]AnswerCreateRequest dto)
        {
            Answer entity = new() { Answers=dto.Answers,QuestionId=dto.QuestionId};
            int result = _answerService.Add(entity);
            return Ok(result>0?"Kayıt başarılı":"Kayıt başarısız");
            
        }
        [HttpPut]
        public IActionResult Put([FromBody]AnswerUpdateRequest dto)
        {
            Answer entity = new() { Id=dto.Id,Answers=dto.Answers,QuestionId=dto.QuestionId};
            bool result=_answerService.Update(entity);
            return Ok(result?entity:null);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _answerService.Delete(new() { Id=id});
            return Ok(result);
        }
       
    }
}
