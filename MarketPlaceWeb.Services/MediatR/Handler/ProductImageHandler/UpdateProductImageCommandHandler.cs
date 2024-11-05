using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler
{
    public class UpdateProductImageCommandHandler : IRequestHandler<UpdateProductImageCommand, bool>
    {
        private readonly IProductImageRepository _repository;

        public UpdateProductImageCommandHandler(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateProductImageCommand request, CancellationToken cancellationToken)
        {

            var oldProductImage = await _repository.GetByIdImages(request.Id);

            if (oldProductImage == null)
                throw new Exception("ProductImage not found!");


            oldProductImage.ImageName = request.ImageName;

            if (oldProductImage.ProductId != request.ProductId)
            {
                oldProductImage.ProductId = request.ProductId;
            }

            await _repository.UpdateImage(oldProductImage,request.Id);
            return true;
        }
    }
}
