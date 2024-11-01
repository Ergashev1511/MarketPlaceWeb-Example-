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
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductViewModel>>
    {
        private readonly IProductRepository _repository;
        public GetAllProductQueryHandler(IProductRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<ProductViewModel>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllProduct();

            return products.Select(a => new ProductViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Describtion = a.Describtion,
                Price = a.Price,
                CategoryViewModel = new CategoryViewModel
                {
                    Id = a.Category?.Id ?? 0,
                    Name = a.Category?.Name ?? "",
                    Description = a.Category?.Describtion ?? "",
                }
            }).ToList();
        }
    }
}
