using MarketPlaceWeb.Services.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public CategoryDto  CategoryDto { get; set; }
    }
}
