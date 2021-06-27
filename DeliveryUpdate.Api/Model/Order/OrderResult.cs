using DeliveryUpdate.Api.Model.Address;
using System;
using System.Collections.Generic;

namespace DeliveryUpdate.Api.Model.Order
{
    public class OrderResult
    {
        public int OrderNumber { get; set; }
        public string OrderDate { get; set; }
        public string DeliveryAddress { get; set; }
        public IList<OrderItemResult> OrderItems { get; set; }
        public string DeliveryExpected { get; set; }
             
    }
}
