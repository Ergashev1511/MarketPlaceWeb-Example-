using FluentValidation;
using MarketPlaceWeb.Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlaceWeb.Services.Common.Validators
{
    public class ProductImageValidator : AbstractValidator<ProductImagesDto>
    {
        public ProductImageValidator()
        {
            RuleFor(a => a.ImageName).
               NotEmpty().
               WithMessage("Category name is required");
        }
    }
}
