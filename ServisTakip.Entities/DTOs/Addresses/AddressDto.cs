﻿using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Entities.DTOs.Addresses
{
    public class AddressDto
    {
        public long CustomerId { get; set; }
        public long QuarterId { get; set; }
        public string AccountCode { get; set; }
        public string NetAddress { get; set; }
        public string AuthorizedName { get; set; }
        public string AuthorizedTask { get; set; }
        public string AuthorizedPhone { get; set; }
        public string AuthorizedEmail { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public List<DeviceDto> Devices { get; set; }
    }
}