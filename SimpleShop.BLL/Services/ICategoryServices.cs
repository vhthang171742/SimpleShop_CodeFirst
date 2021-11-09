using SimpleShop.Models;
using System.Collections.Generic;

namespace SimpleShop.BLL.Services
{
    public interface ICategoryServices
    {
        List<Category> GetCategoryList();
    }
}