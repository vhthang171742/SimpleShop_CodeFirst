using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class MasterCard
    {
        [Key]
        [MaxLength(30, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string CardNo { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Column(TypeName = "date")]
        public DateTime ExpiredMonth { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(3, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string CvcCode { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
