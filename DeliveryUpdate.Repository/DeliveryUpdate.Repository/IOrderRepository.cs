using DeliveryUpdate.Repository.Models;

namespace DeliveryUpdate.Repository
{
    public interface IOrderRepository
    {
        Order GetMostRecentOrder(string customerId);
    }
}
