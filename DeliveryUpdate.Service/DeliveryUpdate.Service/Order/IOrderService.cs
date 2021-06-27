namespace DeliveryUpdate.Service.Order
{
    public interface IOrderService
    {
        Dto.Order GetMostRecentOrder(string customerId);
    }
}
