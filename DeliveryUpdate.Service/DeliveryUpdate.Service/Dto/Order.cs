using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryUpdate.Service.Dto
{
    public class Order
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool ContainsGift { get; set; }
        public string ShippingMode { get; set; }
        public string OrderSource { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
