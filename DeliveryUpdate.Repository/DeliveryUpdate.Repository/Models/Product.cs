using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryUpdate.Repository.Models
{
    [Table("PRODUCTS")]
    public class Product
    {
        [Column("PRODUCTID")]
        public int ProductId { get; set; }
        [Column("PRODUCTNAME")]
        public string ProductName { get; set; }
        [Column("PACKHEIGHT")]
        public decimal PackHeight { get; set; }
        [Column("PACKWIDTH")]
        public decimal PackWidth { get; set; }
        [Column("PACKWEIGHT")]
        public decimal PackWeight { get; set; }
        [Column("COLOUR")]
        public string Colour { get; set; }
        [Column("SIZE")]
        public string Size { get; set; }
    }
}
