using DeliveryUpdate.Api.Model.Customer;
using DeliveryUpdate.Api.Model.Order;

namespace DeliveryUpdate.Api.Model.CustomerOrder
{
    public class CustomerOrderResult
    {
        public CustomerResult Customer { get; set; }
        public OrderResult Order { get; set; }
    }
}
