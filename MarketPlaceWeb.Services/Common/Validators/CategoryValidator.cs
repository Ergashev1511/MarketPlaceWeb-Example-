using FluentValidation;
using MarketPlaceWeb.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Common.Validators
{
    public  class CategoryValidator : AbstractValidator<CategoryDto>
    {
        public CategoryValidator()
        {
            RuleFor(a=>a.Name).
                NotEmpty().
                WithMessage("Category name is required");
        }
    }
}
