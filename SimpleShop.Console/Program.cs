using Microsoft.Extensions.DependencyInjection;
using SimpleShop.Models;
using SimpleShop.DAL.Repositories;
using System;
using SimpleShop.BLL.Services;

namespace SimpleShop.Present
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddScoped<ICategoryRepository, CategoryRepository>();
            var provider = collection.BuildServiceProvider();
            var categoryRepository = provider.GetService<ICategoryRepository>();

            CategoryServices categoryServices = new CategoryServices(categoryRepository);

            foreach(var category in categoryServices.GetCategoryList())
            {
                Console.WriteLine($"Name: {category.Name}");
            }

            Console.WriteLine("Hello World!");
        }
    }
}
