using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.DeviceModels;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Entities.DTOs.Devices
{
    public class DeviceDto
    {
        public long Id { get; set; }
        public long AddressId { get; set; }
        public long DeviceModelId { get; set; }
        public string SerialNumber { get; set; }
        public DateTime AssemblyDate { get; set; }
        public string AssemblyDateString => AssemblyDate.ToString("dd/MM/yyyy");
        public string Description { get; set; }
        public bool Status { get; set; }
        public string RowId { get; set; }
        public ContractDto LastContract => Contracts.MaxBy(s => s.EndDate);
        public AddressDto Address { get; set; }
        public DeviceModelDto DeviceModel { get; set; }
        public List<DeviceServiceDto> DeviceServices { get; set; }
        public List<ContractDto> Contracts { get; set; }
    }
}
