using DeliveryUpdate.Api.Model.Customer;
using DeliveryUpdate.Api.Model.CustomerOrder;
using DeliveryUpdate.Api.Model.Order;
using DeliveryUpdate.Service.Customer;
using DeliveryUpdate.Service.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryUpdate.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        public OrderController(ILogger<OrderController> logger, IOrderService orderService, ICustomerService customerService)
        {
            _logger = logger;
            _orderService = orderService;
            _customerService = customerService;
        }

        /// <summary>
        /// Gets the most recent customer order
        /// </summary>
        /// <response code="200">Recent order details returned</response>
        /// <response code="404">Customer not found</response>
        /// <response code="409">Invalid customer request</response>
        /// <response code="400">Bad request received</response>
        [HttpPost]
        [Route("GetMostRecentOrder")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CustomerOrderResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status409Conflict)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CustomerOrderResult>> GetMostRecentOrder(CustomerOrderRequest customerOrderRequest)
        {
            var customerResponse = await _customerService.GetCustomer(new CustomerRequest
            {
                Email = customerOrderRequest.User,
                CustomerId = customerOrderRequest.CustomerId
            });

            return customerResponse.StatusCode switch
            {
                System.Net.HttpStatusCode.OK => Ok(GetMostRecentOrder(customerResponse.Result)),
                System.Net.HttpStatusCode.NotFound => NotFound("Specified customer not found"),
                System.Net.HttpStatusCode.Conflict => Conflict("Invalid customer request"),
                _ => BadRequest("Bad request")
            };
        }

        private CustomerOrderResult GetMostRecentOrder(CustomerResponseResult customer)
        {
            var model = new CustomerOrderResult
            {
                Customer = new CustomerResult
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                }
            };

            var result = _orderService.GetMostRecentOrder(customer.CustomerId);

            if (result != null)
            {
                var deliveryAddress = string.Join(", ", (new List<string> { customer.Street, customer.Town, customer.Postcode }));

                model.Order = new OrderResult
                {
                    OrderNumber = result.OrderId,
                    OrderDate = result.OrderDate.ToString("dd-MMM-yyyy"),
                    DeliveryAddress = $"{customer.HouseNumber} {deliveryAddress}",
                    DeliveryExpected = result.DeliveryDate.ToString("dd-MMM-yyyy"),
                    OrderItems = result.OrderItems.Select(s => new OrderItemResult
                    {
                        Product = s.Product.ProductName,
                        Quantity = s.Quantity,
                        PriceEach = s.Price
                    }).ToList()
                };
            }

            return model;
        }
    }
}