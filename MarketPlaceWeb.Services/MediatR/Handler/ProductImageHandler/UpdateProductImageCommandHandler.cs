using MarketPlaceWeb.Services.DTO;
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
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, bool>
    {
        private readonly IProductImageService _service;
        public UpdateProductImageCommandHandler(IProductImageService service)
        {
            _service = service;
        }
        public async Task<bool> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage=await _service.GetByIdProductImage(request.Id);
            if (productImage == null) return false;

            ProductImagesDto productImagesDto = new ProductImagesDto()
            {
                ImageName = productImage.Name,
                ProductId = productImage.Id,
            };

            await _service.UpdateProductImage(productImagesDto, request.Id);
            return true;
        }
    }
}
