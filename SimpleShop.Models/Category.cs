using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal MinPrice { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal MaxPrice { get; set; }

        [MaxLength(1000, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
