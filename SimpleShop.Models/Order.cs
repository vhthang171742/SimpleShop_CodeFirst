using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleShop.Models
{
    public enum PaymentMethod { ATM, MasterCard, Cash }
    public enum OrderStatus { Cancelled, Completed }

    public class Order
    {
        public Order()
        {
            this.ProductOrders = new HashSet<ProductOrder>();
        }

        [Key]
        [MaxLength(450, ErrorMessage = "The maximum length of {0} is {1}.")]
        public string OrderCode { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        public string Remarks { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DeliverDate { get; set; }

        public string DeliverStatus { get; set; }

        public string PaymentStatus { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal DiscountAmount { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal ShippingFee { get; set; }

        public decimal Amount {
            get
            {
                decimal total = 0m;
                foreach (var productOrder in this.ProductOrders)
                {
                    total += productOrder.Price * productOrder.Quantity - productOrder.SaleOff;
                }
                total += this.ShippingFee;
                total -= this.DiscountAmount;
                return total;
            }
        }

        private PaymentMethod paymentMethod;
        public PaymentMethod PaymentMethod
        {
            get { return this.paymentMethod; }
            set
            {
                this.paymentMethod = value;
            }
        }

        private OrderStatus orderStatus;
        public OrderStatus OrderStatus
        {
            get { return this.orderStatus; }
            set
            {
                this.orderStatus = value;
            }
        }

        public virtual ICollection<ProductOrder> ProductOrders { get; set; }
    }
}
