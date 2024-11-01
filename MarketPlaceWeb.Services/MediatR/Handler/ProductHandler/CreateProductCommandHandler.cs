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
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, long>
    {
        private readonly IProductRepository _repository;
        public CreateProductCommandHandler(IProductRepository repository)
        {
            _repository = repository;
        }
    
       async Task<long> IRequestHandler<CreateProductCommand, long>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product
            {
                Name = request.ProductDto.Name,
                Describtion = request.ProductDto.Describtion,
                Price = request.ProductDto.Price,
                CategoryId = request.ProductDto.CategoryId,
            };


            var Id = await _repository.AddProduct(product);
            return Id;
        }
    }
}
