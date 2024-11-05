using MarketPlaceWeb.Services.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.ProductQuery
{
    public class CreateProductCommand : IRequest<long>
    {
        public ProductDto  ProductDto { get; set; }
    }
}
