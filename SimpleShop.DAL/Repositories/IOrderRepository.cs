using SimpleShop.Models;
using System.Collections.Generic;

namespace SimpleShop.DAL.Repositories
{
    public interface IOrderRepository
    {
        bool CancelOrder(Order order);
        bool Order(Order order);
        void UpdateStockQuantity(List<ProductOrder> productOrders);
    }
}