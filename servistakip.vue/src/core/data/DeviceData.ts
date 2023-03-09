import { IAddressData } from "./AddressData";
import { IDeviceModelData } from "./DeviceModelData";

interface IDeviceData {
    id?: string | '',
    addressId?: string | '',
    deviceModelId?: string | '',
    serialNumber?: string | '',
    assemblyDate?: string | '',
    assemblyDateString?: string | '',
    description?: string | '',
    status?: boolean | null | undefined,
    address?: IAddressData | null;
    rowId?: string | null;
    deviceModel?: IDeviceModelData | null;
}

export { IDeviceData };