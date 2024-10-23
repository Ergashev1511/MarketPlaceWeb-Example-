using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> CreateCategory(CategoryDto category)
        {
            return Ok(await _service.AddCategory(category));
        }

        [HttpDelete("{Id}")]
        public async ValueTask<IActionResult> DeleteCateogory(long Id)
        {
            return Ok(await _service.DeleteCategory(Id));
        }

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetByCateogyId(long Id)
        {
            return Ok(await _service.GetCategoryById(Id));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllCategory()
        {
            return Ok(await _service.GetAllCategory());
        }

        [HttpPut("{Id}")]
        public async ValueTask<IActionResult> UpdateCateogry(CategoryDto category,long Id)
        {
            return Ok(await _service.UpdateCategory(category, Id));
        }
    }
}
