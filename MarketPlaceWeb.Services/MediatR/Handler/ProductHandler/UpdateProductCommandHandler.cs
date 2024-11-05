using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.ProductQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductHandler
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        public UpdateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;   
        }
        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product=await _repository.GetProductById(request.Id);
           product = new Product()
            {
                Name = request.ProductDto.Name,
                Describtion = request.ProductDto.Describtion,
                Price = request.ProductDto.Price,
                CategoryId = request.ProductDto.CategoryId
            };
            await _repository.UpdateProduct(product, request.Id);

            return true;
        }
    }
}
