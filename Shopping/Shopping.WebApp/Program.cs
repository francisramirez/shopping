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

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
