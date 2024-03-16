using Microsoft.EntityFrameworkCore;
using shopping.Infrastructure.Context;
using shopping.Ioc.CategoryDependency;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Conn Strings
builder.Services.AddDbContext<ShopContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("ShopContext")));

// Course Dependencies //

builder.Services.AddCategoryDependency();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
