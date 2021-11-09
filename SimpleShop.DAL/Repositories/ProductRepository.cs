using SimpleShop.Models;
using SimpleShop.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.Repositories
{
    class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private OrderRepository orderRepository;
        private ProductRepository productRepository;

        public ProductRepository()
        {
            orderRepository = new OrderRepository();
            productRepository = new ProductRepository();
        }

        public List<ProductViewModels> BestSellingProducts(DateTime startDate, DateTime endDate, int size = 10)
        {
            var orderList = orderRepository
                .FindAll(o => o.OrderStatus == OrderStatus.Completed && o.OrderDate >= startDate && o.OrderDate <= endDate, includeProperties: "ProductOders");

            List<ProductOrder> productOrderList = new List<ProductOrder>();
            foreach (var order in orderList)
            {
                productOrderList.AddRange(order.ProductOrders);
            }

            List<ProductViewModels> list = productOrderList.GroupBy(po => po.ProductId)
                .Select(p => new ProductViewModels()
                {
                    Id = p.Key
                ,
                    ImageUrl = p.First().Product.ImageUrl
                ,
                    Name = p.First().Product.Name
                ,
                    ShortDescription = p.First().Product.ShortDescription
                ,
                    TotalSale = p.Sum(q => q.Quantity)
                }).OrderByDescending(vpd => vpd.TotalSale).Take(size).ToList();

            return list;
        }

        public List<ProductViewModels> GetNotSaleProducts(DateTime startDate, DateTime endDate)
        {
            var orderList = orderRepository
                .FindAll(o => o.OrderStatus == OrderStatus.Completed && o.OrderDate >= startDate && o.OrderDate <= endDate, includeProperties: "ProductOders");

            List<ProductOrder> productOrderList = new List<ProductOrder>();
            foreach (var order in orderList)
            {
                productOrderList.AddRange(order.ProductOrders);
            }

            List<ProductViewModels> list = productOrderList.GroupBy(po => po.ProductId)
                .Select(p => new ProductViewModels()
                {
                    Id = p.Key
                ,
                    ImageUrl = p.First().Product.ImageUrl
                ,
                    Name = p.First().Product.Name
                ,
                    ShortDescription = p.First().Product.ShortDescription
                ,
                    TotalSale = p.Sum(q => q.Quantity)
                }).Where(vpd => vpd.TotalSale == 0).ToList();

            return list;
        }

        public List<Product> GetInStockProducts(int days = 7)
        {
            return productRepository.FindAll(p => p.StoredDateTime.AddDays(days) <= DateTime.Today)
                .Where(p1 => p1.StockQuantity >= 1).ToList();
        }

        public List<Product> GetLowQuantityProducts(int minimum = 10)
        {
            return productRepository.FindAll(p => p.StockQuantity < minimum).ToList();
        }
    }
}
