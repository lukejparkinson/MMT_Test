using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryUpdate.Repository.Models
{
    [Table("ORDERS")]
    public class Order
    {
        [Column("ORDERID")]
        public int OrderId { get; set; }
        [Column("CUSTOMERID")]
        public string CustomerId { get; set; }
        [Column("ORDERDATE")]
        public DateTime OrderDate { get; set; }
        [Column("DELIVERYEXPECTED")]
        public DateTime DeliveryDate { get; set; }
        [Column("CONTAINSGIFT")]
        public bool ContainsGift { get; set; }
        [Column("SHIPPINGMODE")]
        public string ShippingMode { get; set; }
        [Column("ORDERSOURCE")]
        public string OrderSource { get; set; }
        public IList<OrderItem> OrderItems { get; set; }
    }
}
