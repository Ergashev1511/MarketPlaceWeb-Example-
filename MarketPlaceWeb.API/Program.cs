using MarketPlaceWeb.API.Configurations;
using MarketPlaceWeb.API.Extensions;
using MarketPlaceWeb.DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextes(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddServices();
builder.ConfigurationValidators();

builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.CreateProductImageCommand).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.DeleteProductImageCommand).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.GetAllProductImagesQuery).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.GetByIdProductImageQuery).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Commands.ProductImageQuery.UpdateProductImageCommand).Assembly);

builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler.CreateProductImageCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler.DeleteProductImageCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler.GetAllProductImagesQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler.GetByIdProductImageQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(MarketPlaceWeb.Services.MediatR.Handler.ProductImageHandler.UpdateProductImageCommandHandler).Assembly);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
