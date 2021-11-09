using SimpleShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.Repositories
{
    public class ProductOrderRepository : BaseRepository<ProductOrder>, IProductOrderRepository
    {
        private OrderRepository orderRepository;

        public ProductOrderRepository()
        {
            this.orderRepository = new OrderRepository();
        }



        public decimal GetTotalSaleByDay(DateTime dateTime)
        {
            var productOrderList = new List<ProductOrder>();

            foreach (var order in orderRepository.FindAll(o => o.OrderDate == dateTime, includeProperties: "ProductOrders"))
            {
                productOrderList.AddRange(order.ProductOrders);
            }

            return productOrderList.Sum(po => po.Quantity);
        }

        public decimal GetTotalSaleByMonth(DateTime dateTime)
        {
            var productOrderList = new List<ProductOrder>();

            foreach (var order in orderRepository.FindAll(o => o.OrderDate.Month == dateTime.Month && dateTime.Year == o.OrderDate.Year, includeProperties: "ProductOrders"))
            {
                productOrderList.AddRange(order.ProductOrders);
            }

            return productOrderList.Sum(po => po.Quantity);
        }

        public decimal GetTotalSaleByYear(int year)
        {
            var productOrderList = new List<ProductOrder>();

            foreach (var order in orderRepository.FindAll(o => o.OrderDate.Year == year, includeProperties: "ProductOrders"))
            {
                productOrderList.AddRange(order.ProductOrders);
            }

            return productOrderList.Sum(po => po.Quantity);
        }
    }
}
