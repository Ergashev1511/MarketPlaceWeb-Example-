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
    public class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQuery, ProductImageViewModel>
    {
        private readonly IProductImageService _service;
        public GetByIdProductImageQueryHandler(IProductImageService service)
        {
            _service = service;
        }
        public async Task<ProductImageViewModel> Handle(GetByIdProductImageQuery request, CancellationToken cancellationToken)
        {
            var productImage = await _service.GetByIdProductImage(request.Id);
            if (productImage == null) return new ProductImageViewModel();
            return productImage;
        }
    }
}
