using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MarketPlaceWeb.Services.Services.IServices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, bool>
    {
        private readonly IProductImageService _service;
        public DeleteProductImageCommandHandler(IProductImageService service)
        {
            _service = service;
        }
        async Task<bool>  IRequestHandler<DeleteProductImageCommand, bool>.Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _service.GetByIdProductImage(request.Id);
            if(productImage == null) return false;

            await _service.DeleteProductImage(request.Id);
            return true;
        }
    }
}
