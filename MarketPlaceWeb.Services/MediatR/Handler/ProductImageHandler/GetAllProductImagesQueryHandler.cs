using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MarketPlaceWeb.Services.Services.IServices;
using MarketPlaceWeb.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler
{
    public class GetAllProductImagesQueryHandler : IRequestHandler<GetAllProductImagesQuery, List<ProductImageViewModel>>
    {
        private readonly IProductImageService _service;
        public GetAllProductImagesQueryHandler(IProductImageService service)
        {
            _service = service; 
        }
        public async Task<List<ProductImageViewModel>> Handle(GetAllProductImagesQuery request, CancellationToken cancellationToken)
        {
            var productImages = await _service.GetAllProductImages();

            return productImages;
        }
    }
}
