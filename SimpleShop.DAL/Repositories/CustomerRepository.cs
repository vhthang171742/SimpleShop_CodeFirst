using SimpleShop.Models;
using SimpleShop.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        private OrderRepository orderRepository;

        public CustomerRepository()
        {
            this.orderRepository = new OrderRepository();
        }

        public List<CustomerViewModel> TopBuyer(int size, decimal totalCash)
        {
            var list = orderRepository.FindAll(includeProperties: "Customer")
                .GroupBy(o => o.CustomerId)
                .Select(x => new CustomerViewModel()
                {
                    CustomerId = x.First().CustomerId,
                    FirstName = x.First().Customer.FirstName,
                    LastName = x.First().Customer.LastName,
                    Address = x.First().Customer.Address,
                    PhoneNumber = x.First().Customer.PhoneNumber,
                    TotalCash = x.Sum(y => y.Amount)
                }).Where(z => z.TotalCash >= totalCash).Take(size).ToList();

            return list;
        }
    }
}
