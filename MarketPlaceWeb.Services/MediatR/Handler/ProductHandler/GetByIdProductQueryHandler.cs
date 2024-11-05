using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Services.MediatR.Commands.ProductQuery;
using MarketPlaceWeb.Services.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductHandler
{
    public class GetByIdProductQueryHandler : IRequestHandler<GetByIdProductQuery, ProductViewModel>
    {
        private readonly IProductRepository _repository;
        public GetByIdProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<ProductViewModel> Handle(GetByIdProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetProductById(request.Id);

            ProductViewModel productViewModel = new ProductViewModel()
            {
                Name = product.Name,
                Describtion = product.Describtion,
                Price = product.Price,
                CategoryViewModel = new CategoryViewModel
                {
                    Id = product.Category?.Id ?? 0,
                    Name = product.Category?.Name ?? "Unknown",
                    Description = product.Category?.Describtion ?? "No description",
                }
            };

            return productViewModel; throw new NotImplementedException();
        }
    }
}
