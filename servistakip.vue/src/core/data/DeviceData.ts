import { IAddressData } from "./AddressData";
import { IDeviceModelData } from "./DeviceModelData";

interface IDeviceData {
    addressId?: string | '',
    deviceModelId?: string | '',
    serialNumber?: string | '',
    assemblyDateString?: string | '',
    description?: string | '',
    status?: string | '',
    address?: IAddressData | null;
    deviceModel?: IDeviceModelData | null;
}

export { IDeviceData };