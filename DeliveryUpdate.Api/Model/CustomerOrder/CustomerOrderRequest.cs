using DeliveryUpdate.Api.Model.Customer;
using System.ComponentModel.DataAnnotations;

namespace DeliveryUpdate.Api.Model.CustomerOrder
{
    /// <summary>
    /// The request object requiring customer identifiers
    /// </summary>
    public class CustomerOrderRequest
    {
        /// <summary>
        /// The email address of the customer
        /// </summary>
        [Required]
        public string User { get; set; }
        /// <summary>
        /// The Customer Identifier
        /// </summary>
        [Required]
        public string CustomerId { get; set; }
    }
}
