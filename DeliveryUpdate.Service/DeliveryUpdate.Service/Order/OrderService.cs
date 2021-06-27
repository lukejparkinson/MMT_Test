using DeliveryUpdate.Repository;
using DeliveryUpdate.Service.Dto;
using System.Linq;

namespace DeliveryUpdate.Service.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService (IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Dto.Order GetMostRecentOrder(string customerId)
        {
            var model = _orderRepository.GetMostRecentOrder(customerId);

            if (model != null)
            {
                return new Dto.Order
                {
                    OrderId = model.OrderId,
                    CustomerId = model.CustomerId,
                    OrderDate = model.OrderDate,
                    DeliveryDate = model.DeliveryDate,
                    ContainsGift = model.ContainsGift,
                    ShippingMode = model.ShippingMode,
                    OrderSource = model.OrderSource,
                    OrderItems = model.OrderItems.Select(s => new OrderItem
                    {
                        OrderItemId = s.OrderItemId,
                        OrderId = s.OrderId,
                        ProductId = s.ProductId,
                        Quantity = s.Quantity,
                        Price = s.Price,
                        Returnable = s.Returnable,
                        Product = new Product
                        {
                            ProductId = s.Product.ProductId,
                            ProductName = s.Product.ProductName,
                            PackHeight = s.Product.PackHeight,
                            PackWidth = s.Product.PackWidth,
                            PackWeight = s.Product.PackWeight,
                            Colour = s.Product.Colour,
                            Size = s.Product.Size
                        }
                    }).ToList()
                };
            }

            return null;
        }
    }
}
