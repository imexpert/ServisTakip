import { IAddressData } from "./AddressData";
import { IDeviceModelData } from "./DeviceModelData";

interface IDeviceData {
    id : string | null,
    addressId?: string | '',
    deviceModelId?: string | '',
    serialNumber?: string | '',
    assemblyDate?: Date | '',
    assemblyDateString?: string | '',
    description?: string | '',
    status?: boolean | null | undefined,
    address?: IAddressData | null;
    rowId?: string | null;
    deviceModel?: IDeviceModelData | null;
    maintenancePeriod?: string | null;
}

export { IDeviceData };