using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class Product
    {
        public Product()
        {
            this.ProductOrders = new HashSet<ProductOrder>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Name { get; set; }

        [MaxLength(1000, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string ShortDescription { get; set; }

        [Column(TypeName="ntext")]
        public string FullDescription { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal Price { get; set; }

        public decimal SalePrice { get; set; }

        [MaxLength(1000, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public bool IsNewArrive { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime IsNewToDateTime { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal StockQuantity { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime ManufactureDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StoredDateTime { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
