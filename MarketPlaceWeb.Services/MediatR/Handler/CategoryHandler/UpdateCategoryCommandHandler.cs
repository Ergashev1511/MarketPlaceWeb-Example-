using FluentValidation;
using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.Domain.Entities;
using MarketPlaceWeb.Services.Common.Exceptions;
using MarketPlaceWeb.Services.DTO;
using MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.MediatR.Handler.CategoryHandler
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICateogryRepository _repository;
        private readonly IValidator<CategoryDto> _validator;
        public UpdateCategoryCommandHandler(ICateogryRepository repository,IValidator<CategoryDto> validator)
        {
            _repository = repository;
            _validator = validator;
        }
        async Task<bool> IRequestHandler<UpdateCategoryCommand, bool>.Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request.CategoryDto);
            if (!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult.Errors.First().ErrorMessage);
            }

            var category =await _repository.GetCategoryById(request.Id);
            if (category == null) throw new Exception("Category not found!");
            category = new Category()
            {
                Name = request.CategoryDto.Name,
                Describtion = request.CategoryDto.Description,
                ParentCategoryId = request.CategoryDto.ParentCategoryId,
            };

            await _repository.UpdateCategory(category, request.Id);
            return true;
        }
    }
}
