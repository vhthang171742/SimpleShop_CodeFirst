using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class ProductOrder
    {
        [Key]
        [MaxLength(450, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string OrderCode { get; set; }

        public virtual Order Order { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal SaleOff { get; set; }

        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Remarks { get; set; }

    }
}
