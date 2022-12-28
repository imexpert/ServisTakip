﻿using ServisTakip.Core.Entities;

namespace ServisTakip.Entities.Concrete
{
    public class Company : BaseEntity
    {
        public string Title { get; set; }
        public int NumberOfUser { get; set; }
        public string Phone { get; set; }
        public bool Status { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
