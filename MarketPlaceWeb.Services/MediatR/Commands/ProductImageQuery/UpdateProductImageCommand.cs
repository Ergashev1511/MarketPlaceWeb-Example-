using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery
{
    public class UpdateProductImageCommand : IRequest<bool>
    {
        public long Id { get; set; }
        public string ImageName { get; set; }
        public long ProductId { get; set; }
    }
}
