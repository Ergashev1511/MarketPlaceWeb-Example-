using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery
{
    public class GetByIdProductImageQuery : IRequest<ProductImageViewModel>
    {
        public long Id { get; set; }
    }
}
