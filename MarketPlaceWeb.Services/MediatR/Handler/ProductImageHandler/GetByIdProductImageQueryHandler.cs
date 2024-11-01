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
    public class GetByIdProductImageQueryHandler : IRequestHandler<GetByIdProductImageQuery, ProductImageViewModel>
    {
        private readonly IProductImageRepository _repository;
        public GetByIdProductImageQueryHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductImageViewModel> Handle(GetByIdProductImageQuery request, CancellationToken cancellationToken)
        {
            var productImage = await _repository.GetByIdImages(request.Id);
            ProductImageViewModel viewModel = new ProductImageViewModel()
            {
                Id = productImage.Id,
                Name = productImage.ImageName,
                ProductId = productImage.ProductId
            };
            return viewModel;
        }
    }
}
