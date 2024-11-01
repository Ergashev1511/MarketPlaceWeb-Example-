using MarketPlaceWeb.DataAccess.DBContext;
using MarketPlaceWeb.DataAccess.Repositories.IRepository;
using MarketPlaceWeb.DataAccess.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace MarketPlaceWeb.API.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddDbContextes(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICateogryRepository, CategoryRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
        }

       /* public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductImageService, ProductImagesService>();
        }*/
    }
}
