using DeliveryUpdate.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryUpdate.Service.Customer
{
    public class CustomerResponseResult : CustomerBase
    {
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string Town { get; set; }
        public string Postcode { get; set; }
        public string LastLoggedIn { get; set; }
    }
}
