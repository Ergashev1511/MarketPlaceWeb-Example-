using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
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
        private readonly IProductImageRepository _repository;

        public GetAllProductImagesQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductImageViewModel>> Handle(GetAllProductImagesQuery request, CancellationToken cancellationToken)
        {
            var productImages = await _repository.GetAllImages();
            return productImages.Select(a => new ProductImageViewModel()
            {
                Id = a.Id,
                Name = a.ImageName,
                ProductId = a.ProductId
            }).ToList();
        }
    }
}
