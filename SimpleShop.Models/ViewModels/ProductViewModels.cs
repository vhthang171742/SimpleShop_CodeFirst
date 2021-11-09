using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.DAL.ViewModels
{
    public class ProductViewModels
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortDescription { get; set; }

        public string ImageUrl { get; set; }

        public decimal TotalSale { get; set; }
    }
}
