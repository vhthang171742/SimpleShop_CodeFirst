using SimpleShop.DAL.ViewModels;
using System.Collections.Generic;

namespace SimpleShop.DAL.Repositories
{
    public interface ICustomerRepository
    {
        List<CustomerViewModel> TopBuyer(int size, decimal totalCash);
    }
}