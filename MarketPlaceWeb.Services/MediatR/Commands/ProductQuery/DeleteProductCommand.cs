using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Commands.ProductQuery
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public long Id { get; set; }
    }
}
