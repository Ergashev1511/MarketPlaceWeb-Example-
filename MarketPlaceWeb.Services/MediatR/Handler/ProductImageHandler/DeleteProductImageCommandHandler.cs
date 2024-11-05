using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler
{
    public class DeleteProductImageCommandHandler : IRequestHandler<DeleteProductImageCommand, bool>
    {
        private readonly IProductImageRepository _repository;
        public DeleteProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;   
        }
        async Task<bool>  IRequestHandler<DeleteProductImageCommand, bool>.Handle(DeleteProductImageCommand request, CancellationToken cancellationToken)
        {
            var productImage = await _repository.GetByIdImages(request.Id);

            if (productImage == null) throw new Exception("ProductImage not found");

            await _repository.DeleteImage(productImage);
            return true;
        }
    }
}
