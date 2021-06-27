using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryUpdate.Repository.Models
{
    [Table("ORDERITEMS")]
    public class OrderItem
    {
        [Column("ORDERITEMID")]
        public int OrderItemId { get; set; }
        [Column("ORDERID")]
        public int OrderId { get; set; }
        [Column("PRODUCTID")]
        public int ProductId { get; set; }
        [Column("QUANTITY")]
        public int Quantity { get; set; }
        [Column("PRICE")]
        public decimal Price { get; set; }
        [Column("RETURNABLE")]
        public bool Returnable { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }       
    }
}
