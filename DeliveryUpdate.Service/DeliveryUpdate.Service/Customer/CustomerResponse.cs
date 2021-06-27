using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryUpdate.Service.Customer
{
    public class CustomerResponse
    {
        public CustomerResponse()
        {
        }

        public CustomerResponse(CustomerResponseResult result, CustomerRequest customerRequest)
        {
            if (customerRequest.CustomerId == result.CustomerId &&
                customerRequest.Email == result.Email)
            {
                Result = result;
                StatusCode = System.Net.HttpStatusCode.OK;
            }
            else
            {
                StatusCode = System.Net.HttpStatusCode.Conflict;
            }
        }
        public CustomerResponse(System.Net.HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
        public CustomerResponseResult Result { get; set; }
        public System.Net.HttpStatusCode StatusCode { get; set; }
    }
}
