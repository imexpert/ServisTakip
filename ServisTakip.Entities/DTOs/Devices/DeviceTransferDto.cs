using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.DeviceModels;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Entities.DTOs.Devices
{
    public class DeviceTransferDto
    {
        public long MusteriId { get; set; }
        public long AdresId { get; set; }
        public long CihazId { get; set; }
        public long TransferMusteriId { get; set; }
        public long TransferAdresId { get; set; }
    }
}
