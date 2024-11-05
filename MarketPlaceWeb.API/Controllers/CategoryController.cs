using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery;
using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MarketPlaceWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;   
        }

        [HttpPost("Create")]
        public async ValueTask<IActionResult> CreateCategory([FromBody]CreateCategoryCommands category)
        {
            var res=await _mediator.Send(category);
            return Ok(res);
        }

        [HttpDelete("{Id}")]
        public async ValueTask<IActionResult> DeleteCateogory(long Id)
        {
            var res = await _mediator.Send(new DeleteCategoryCommands { Id = Id });
            return NoContent();
        }

        [HttpGet("{Id}")]
        public async ValueTask<IActionResult> GetByCateogyId(long Id)
        {
            var res = await _mediator.Send(new GetByIdCategoryQuery { Id = Id });
            return Ok(res);
        }

        [HttpGet("GetAll")]
        public async ValueTask<IActionResult> GetAllCategory()
        {
            var res = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(res);
        }

        [HttpPut("{Id}")]
        public async ValueTask<IActionResult> UpdateCateogry([FromBody]UpdateCategoryCommand command,long Id)
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
