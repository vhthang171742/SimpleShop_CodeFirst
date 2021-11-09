using SimpleShop.DAL.ViewModels;
using SimpleShop.Models;
using System;
using System.Collections.Generic;

namespace SimpleShop.DAL.Repositories
{
    interface IProductRepository
    {
        List<ProductViewModels> BestSellingProducts(DateTime startDate, DateTime endDate, int size = 10);
        List<Product> GetInStockProducts(int days = 7);
        List<Product> GetLowQuantityProducts(int minimum = 10);
        List<ProductViewModels> GetNotSaleProducts(DateTime startDate, DateTime endDate);
    }
}