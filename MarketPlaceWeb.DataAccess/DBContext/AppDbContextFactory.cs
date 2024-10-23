﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
namespace MarketPlaceWeb.DataAccess.DBContext
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Update this path to point to the correct location of appsettings.json
            var path = Directory.GetCurrentDirectory();
            // Adjust for when running migrations from the DataAccess project
            if (!File.Exists(Path.Combine(path, "appsettings.json")))
            {
                path = Path.Combine(path, "..", "MarketPlaceWeb.API"); // Adjust based on the main project path
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseNpgsql(connectionString);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
