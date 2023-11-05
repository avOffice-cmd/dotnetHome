﻿namespace DI_MiddleWare_Configuration2.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public List<Order> Orders { get; set; }
    }
}
