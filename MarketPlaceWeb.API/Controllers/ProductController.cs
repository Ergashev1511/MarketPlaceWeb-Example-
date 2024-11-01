using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.ProductQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator  _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        

        [HttpPost("Create")]
        public async ValueTask<IActionResult> CreateProduct([FromBody]CreateProductCommand productDto)
        {
            var res=await _mediator.Send(productDto);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async ValueTask<IActionResult> DeleteProduct(long Id)
        {
            var res=await _mediator.Send(new DeleteProductCommand { Id = Id });
            return NoContent();
        }

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult>  GetByIdProduct(long Id)
        {
            var res=await _mediator.Send(new GetByIdProductQuery { Id = Id });  
            return Ok(res);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllProduct()
        {
            var res = await _mediator.Send(new GetAllProductQuery());
            return Ok(res);
        }

        [HttpPut("{Id}")]
        public async ValueTask<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command, long Id)
        {
            if (Id != command.Id)
            {
                return BadRequest();
            }

            var res = await _mediator.Send(command);
            if (!res)
            {
                NotFound();
            }
            return NoContent();
        }

    }
}
