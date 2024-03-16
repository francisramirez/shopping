
using Microsoft.Extensions.DependencyInjection;
using shopping.Application.Contracts;
using shopping.Application.Service;
using shopping.Infrastructure.Interfaces;
using shopping.Infrastructure.Repositories;

namespace shopping.Ioc.CategoryDependency
{
    public static class CategoryDependency
    {
        public static void AddCategoryDependency(this IServiceCollection service)
        {
            // Repositories
            service.AddScoped<ICategoryRepository, CategoryRepository>();


            // App Services
            //service.AddTransient<ICategoryService, CategoryService>();
            service.AddTransient<ICategoryNewService, CategoryNewService>();

        }
    }
}
