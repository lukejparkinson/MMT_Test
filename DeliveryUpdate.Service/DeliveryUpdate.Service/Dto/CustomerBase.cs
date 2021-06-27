using System;

namespace DeliveryUpdate.Service.Dto
{
    public class CustomerBase
    {
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Website { get; set; }
        public string PreferredLanguage { get; set; }
    }
}
