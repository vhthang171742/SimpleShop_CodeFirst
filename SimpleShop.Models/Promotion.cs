using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class Promotion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MaxLength(10, ErrorMessage = "The maximum length of {0} is {1}")]
        public string PromotionCode { get; set; }

        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}")]
        public string PromotionName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Range(0, 100, ErrorMessage = "{0} must be in range [{1} - {2}]")]
        public decimal DiscountRate { get; set; }
    }
}
