using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery;
using MediatR;
namespace MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler
{
    public class CreateProductImageCommandHandler : IRequestHandler<CreateProductImageCommand, bool>
    {
        private readonly IProductImageRepository _repository;
        
        public CreateProductImageCommandHandler(IProductImageRepository  repository)
        {
            _repository = repository; 
        }
        public async Task<bool> Handle(CreateProductImageCommand request, CancellationToken cancellationToken)
        {
           /* var validationResult = _validator.Validate(productImagesDto);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
            }*/
            ProductImages productImages = new ProductImages()
            {
                ImageName = request.ImageName,
                ProductId = request.ProductId,
            };
            await _repository.AddImage(productImages);
            return true;
        }
    }
}
