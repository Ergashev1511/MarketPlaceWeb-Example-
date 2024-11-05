using MediatR;
using System.Reflection;

namespace MarketPlaceWeb.API.DependencyExtensions
{
    public static class MediatRHandlers
    {
     
         /*   public static IServiceCollection RegisterRequestHandlers(
            this IServiceCollection services)
            {
                return services
                    .AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(MarketPlaceWeb.Services).Assembly));
            }*/
        
        public static IServiceCollection AddMediatRHandlers(this IServiceCollection services)
        {
            // MediatR handlerlarini ro'yxatdan o'tkazish
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.CreateProductImageCommand).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.DeleteProductImageCommand).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.GetAllProductImagesQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.GetByIdProductImageQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.UpdateProductImageCommand).Assembly);

            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductQuery.CreateProductCommand).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductQuery.DeleteProductCommand).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductQuery.GetAllProductQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductQuery.GetByIdProductQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductQuery.UpdateProductCommand).Assembly);

            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery.CreateCategoryCommands).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery.DeleteCategoryCommands).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery.GetAllCategoryQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery.GetByIdCategoryQuery).Assembly);
            services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.CategoryQuery.UpdateCategoryCommand).Assembly);

            return services;
        }
    }
}
