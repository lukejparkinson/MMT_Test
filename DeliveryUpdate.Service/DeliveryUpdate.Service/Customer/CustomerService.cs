using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeliveryUpdate.Service.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerApiConfiguration _configuration;
        private readonly JsonSerializerOptions _jsonOptions;
        public CustomerService(CustomerApiConfiguration configuration)
        {
            _configuration = configuration;
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.PropertyNameCaseInsensitive = true;
        }

        public async Task<CustomerResponse> GetCustomer(CustomerRequest customerRequest)
        {
            using (var httpClient = new HttpClient())
            {
                CustomerResponse result = null;

                var response = await httpClient.PostAsJsonAsync($"{_configuration.Uri}GetUserDetails?code={_configuration.ApiKey}", customerRequest);

                if (response.IsSuccessStatusCode)
                {
                    var contentStream = await response.Content.ReadAsStreamAsync();
                    result = new CustomerResponse(await JsonSerializer.DeserializeAsync<CustomerResponseResult>(contentStream, _jsonOptions), customerRequest);
                }
                else
                {
                    result = new CustomerResponse(response.StatusCode);
                }

                return result switch
                {
                    CustomerResponse success when success.StatusCode == System.Net.HttpStatusCode.OK => result,
                    CustomerResponse notFound when notFound.StatusCode == System.Net.HttpStatusCode.NotFound => new CustomerResponse(System.Net.HttpStatusCode.NotFound),
                    CustomerResponse conflict when conflict.StatusCode == System.Net.HttpStatusCode.Conflict => new CustomerResponse(System.Net.HttpStatusCode.Conflict),
                    _ => throw new Exception("Unknown response")
                };
            }
        }
    }
}
