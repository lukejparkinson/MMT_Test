using System;

namespace DeliveryUpdate.Service.Dto
{
    public class Customer : CustomerBase
    {
        public Address Address { get; set; }
        public DateTime LastLoggedIn { get; set; }
    }
}
