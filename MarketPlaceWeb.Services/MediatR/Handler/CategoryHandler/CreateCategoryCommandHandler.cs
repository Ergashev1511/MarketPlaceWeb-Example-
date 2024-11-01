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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommands, bool>
    {
        private readonly ICateogryRepository _repository;
        private readonly IValidator<CategoryDto> _validator;
        public CreateCategoryCommandHandler(ICateogryRepository repository,IValidator<CategoryDto> validator)
        {
            _repository = repository;   
            _validator = validator;
        }
        public async Task<bool> Handle(CreateCategoryCommands request, CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request.CategoryDto);
            if (!validationResult.IsValid)
            {
                throw new ValidatorException(validationResult.Errors.First().ErrorMessage);
            }

            if (request.CategoryDto.ParentCategoryId == null || request.CategoryDto.ParentCategoryId == 0)
            {
                Category Parentcategory = new Category()
                {
                    Name = request.CategoryDto.Name,
                    Describtion = request.CategoryDto.Description,
                    ParentCategoryId = null,
                };
                await _repository.AddCategory(Parentcategory);
                return true;
            }

            Category ChildCategory = new Category()
            {
                Name = request.CategoryDto.Name,
                Describtion = request.CategoryDto.Description,
                ParentCategoryId = request.CategoryDto.ParentCategoryId,
            };
            await _repository.AddChildCategory(ChildCategory);
            return true;
        }
    }
}
