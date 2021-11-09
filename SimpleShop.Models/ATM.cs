using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class ATMCard
    {
        [Key]
        [MaxLength(15, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string ATMCardNo { get; set; }

        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
