using MarketPlaceWeb.Domain.Entities;
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
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, bool>
    {
        private readonly IProductImageService _service;
        public CreateProductImageCommandHandler(IProductImageService service)
        {
            _service = service; 
        }
        public async Task<bool> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = new DTO.ProductImagesDto
            {
                ImageName = request.ImageName,
                ProductId = request.ProductId
            };
            await _service.AddProductImage(productImage);
            return true;
        }
    }
}
