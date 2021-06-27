using DeliveryUpdate.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DeliveryUpdate.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _orderContext;
        public OrderRepository(OrderContext orderContext)
        {
            _orderContext = orderContext;
        }

        public Order GetMostRecentOrder(string customerId)
        {
            return GetCustomerOrdersQuery(customerId)
                                       .Include(i => i.OrderItems)
                                       .ThenInclude(i => i.Product)
                                       .OrderByDescending(o => o.OrderDate)
                                       .FirstOrDefault();
        }

        private IQueryable<Order> GetCustomerOrdersQuery(string customerId)
        {
            return _orderContext.Orders.Where(x => x.CustomerId == customerId);
        }
    }
}
