namespace DeliveryUpdate.Api.Model.Order
{
    public class OrderItemResult
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal PriceEach { get; set; }
    }
}
