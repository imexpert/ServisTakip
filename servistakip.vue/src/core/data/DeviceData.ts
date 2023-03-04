import { IAddressData } from "./AddressData";
import { IDeviceModelData } from "./DeviceModelData";

interface IDeviceData {
    id?: string | '',
    addressId?: string | '',
    deviceModelId?: string | '',
    serialNumber?: string | '',
    assemblyDateString?: string | '',
    description?: string | '',
    status?: string | '',
    address?: IAddressData | null;
    rowId?: string | null;
    deviceModel?: IDeviceModelData | null;
}

export { IDeviceData };