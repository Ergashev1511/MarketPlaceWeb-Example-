using MarketPlaceWeb.Services.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery
{
    public class CreateCategoryCommands : IRequest<bool>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
