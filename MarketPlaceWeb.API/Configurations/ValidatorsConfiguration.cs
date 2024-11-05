using FluentValidation;
using MarketPlaceWeb.Services.Common.Validators;
using MarketPlaceWeb.Services.DTO;

namespace MarketPlaceWeb.API.Configurations
{
    public static class ValidatorsConfiguration
    {
        public static void ConfigurationValidators(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IValidator<CategoryDto>, CategoryValidator>();

            builder.Services.AddScoped<IValidator<ProductImagesDto>, ProductImageValidator>();
        }
    }
}
