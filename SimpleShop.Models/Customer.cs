using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(255, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(20, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(1000, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int MemberPoint { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public int MemberType { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(30, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string CardNo { get; set; }

        public virtual MasterCard MasterCard { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [MaxLength(15, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string ATMCardNo { get; set; }

        public virtual ATMCard ATMCard { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
