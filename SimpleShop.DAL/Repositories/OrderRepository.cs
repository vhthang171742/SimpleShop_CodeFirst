using SimpleShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private ProductRepository productRepository;
        private OrderRepository orderRepository;
        public OrderRepository()
        {
            this.productRepository = new ProductRepository();
            this.orderRepository = new OrderRepository();
        }

        private bool CheckOrder(List<ProductOrder> productOrders)
        {
            foreach (var productOrder in productOrders)
            {
                var currentProduct = this.productRepository.FindFirstOrDefault(p => p.Id == productOrder.ProductId);
                if (productOrder.Quantity > currentProduct.StockQuantity)
                    return false;
            }

            return true;
        }

        public void UpdateStockQuantity(List<ProductOrder> productOrders)
        {
            foreach (var productOrder in productOrders)
            {
                var currentProduct = this.productRepository.FindFirstOrDefault(p => p.Id == productOrder.ProductId);
                currentProduct.StockQuantity -= productOrder.Quantity;
            }
            productRepository.SaveChanges();
        }

        public bool Order(Order order)
        {
            var currentOrder = this.dbSet.Include(o => o.ProductOrders).ThenInclude(po => po.Product).Where(o => o.OrderCode == order.OrderCode).FirstOrDefault();
            if (currentOrder == null)
                return false;

            if (!CheckOrder((List<ProductOrder>)currentOrder.ProductOrders))
                return false;

            UpdateStockQuantity((List<ProductOrder>)currentOrder.ProductOrders);

            order.OrderStatus = OrderStatus.Completed;
            orderRepository.Add(order);
            orderRepository.SaveChanges();
            return true;
        }

        public bool CancelOrder(Order order)
        {
            var currentOrder = this.dbSet.Include(o => o.ProductOrders).ThenInclude(po => po.Product).Where(o => o.OrderCode == order.OrderCode).FirstOrDefault();
            if (currentOrder == null)
                return false;

            order.OrderStatus = OrderStatus.Cancelled;
            orderRepository.SaveChanges();
            return true;
        }
    }
}
