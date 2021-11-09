using SimpleShop.DAL.Repositories;
using SimpleShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.BLL.Services
{
    public class CategoryServices : ICategoryServices
    {
        private ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public List<Category> GetCategoryList()
        {
            return categoryRepository.GetAll();
        }
    }
}
