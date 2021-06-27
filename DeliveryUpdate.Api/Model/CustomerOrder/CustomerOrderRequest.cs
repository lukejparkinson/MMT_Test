using DeliveryUpdate.Api.Model.Customer;
using System.ComponentModel.DataAnnotations;

namespace DeliveryUpdate.Api.Model.CustomerOrder
{
    public class CustomerOrderRequest
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string CustomerId { get; set; }
    }
}
