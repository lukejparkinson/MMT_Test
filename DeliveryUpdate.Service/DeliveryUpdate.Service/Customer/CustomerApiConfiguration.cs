using Microsoft.Extensions.Configuration;

namespace DeliveryUpdate.Service.Customer
{
    public class CustomerApiConfiguration
    {
        public CustomerApiConfiguration(IConfiguration configuration)
        {
            Uri = configuration.GetSection("CustomerApi").GetValue<string>("Uri");
            ApiKey = configuration.GetSection("CustomerApi").GetValue<string>("ApiKey");
        }

        public string Uri { get; set; }
        public string ApiKey { get; set; }
    }
}
