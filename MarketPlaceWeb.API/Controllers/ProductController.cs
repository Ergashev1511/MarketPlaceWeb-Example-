using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service; 
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> CreateProduct(ProductDto productDto)
        {
            return Ok(await _service.AddProduct(productDto));
        }

        [HttpDelete("{Id}")]
        public async ValueTask<IActionResult> DeleteProduct(long Id)
        {
            return Ok(await _service.DeleteProduct(Id));    
        }

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult>  GetByIdProduct(long Id)
        {
            return Ok(await _service.GetProductById(Id));
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            return Ok(await _service.GetAllProduct());
        }

        [HttpPut("{Id}")]
        public async ValueTask<IActionResult> UpdateProduct(ProductDto productDto, long Id)
        {
            return Ok(await _service.UpdateProduct(productDto, Id));
        }

    }
}
