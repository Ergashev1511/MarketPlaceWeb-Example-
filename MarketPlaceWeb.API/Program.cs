using MarketPlaceWeb.API.Configurations;
using MarketPlaceWeb.API.Extensions;
using MarketPlaceWeb.DataAccess.DBContext;
using Microsoft.EntityFrameworkCore;
using MediatR;
using MarketPlaceWeb.API.DependencyExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContextes(builder.Configuration);
builder.Services.AddRepositories();
builder.ConfigurationValidators();
builder.Services.AddMediatRHandlers();

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
