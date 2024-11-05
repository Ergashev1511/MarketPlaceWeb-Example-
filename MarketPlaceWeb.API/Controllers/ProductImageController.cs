using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketPlaceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductImageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> CreateProductImage([FromBody] CreateProductImageCommand command)
        {
            var res= await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async ValueTask<IActionResult> DeleteProductImage(long Id)
        {
            var res = await _mediator.Send(new DeleteProductImageCommand { Id = Id });
            return NoContent();
        }

        [HttpGet("{Id}")]
         public async ValueTask<IActionResult> GetByIdProductImage(long Id)
        {
            var res=await _mediator.Send(new GetByIdProductImageQuery { Id = Id }); 
            return Ok(res);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllProductImage()
        {
            var res = await _mediator.Send(new GetAllProductImagesQuery());
            return Ok(res);
        }

        [HttpPut("{Id}")]
        public async ValueTask<IActionResult> UpdateProductImage([FromBody] UpdateProductImageCommand command,long Id)
        {
            if(Id!=command.Id)
            {
                return BadRequest();
            }

            var res = await _mediator.Send(command);
            if(!res)
            {
                NotFound();
            }
            return NoContent();
        }
    }
}
