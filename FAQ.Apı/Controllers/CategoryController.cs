using FAQ.Business.Abstract;
using FAQ.Business.Dto;
using FAQ.Business.Dto.Categories;
using FAQ.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FAQ.Apı.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById( int id)
        {
            Category result = _categoryService.Get(c => c.Id == id);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult Post([FromBody] CategoryCreateRequest dto)
        {
            Category entity = new() { Name = dto.Name };
            int result = _categoryService.Add(entity);
            return Ok(result > 0 ? "Kayıt Başarılı" : "Hatalı Kayıt");
        }
        [HttpPut]
        public IActionResult Put([FromBody] CategoryUpdateRequest dto)
        {
            Category entity = new() { Id = dto.Id, Name = dto.Name };
            bool result = _categoryService.Update(entity);
            return Ok(result ? entity : null);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = _categoryService.Delete(new() { Id = id });
            return Ok(result);
        }
    }
}
