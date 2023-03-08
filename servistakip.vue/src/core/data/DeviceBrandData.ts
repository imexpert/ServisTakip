import { IDeviceTypeData } from "./DeviceTypeData";

interface IDeviceBrandData {
    id?: string | '',
    companyId?: string | '',
    name?: string | '',
    deviceType: IDeviceTypeData | null;
}

export { IDeviceBrandData };