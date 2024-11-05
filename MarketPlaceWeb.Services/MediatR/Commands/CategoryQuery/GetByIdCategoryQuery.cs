using MarketPlaceWeb.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery
{
    public class GetByIdCategoryQuery : IRequest<CategoryViewModel>
    {
        public long  Id { get; set; }
    }
}
