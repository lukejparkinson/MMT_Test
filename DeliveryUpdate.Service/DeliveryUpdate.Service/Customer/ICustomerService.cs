using System.Threading.Tasks;

namespace DeliveryUpdate.Service.Customer
{
    public interface ICustomerService
    {
        Task<CustomerResponse> GetCustomer(CustomerRequest customerRequest);
    }
}
