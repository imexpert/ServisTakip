import { IDeviceTypeData } from "./DeviceTypeData";

interface IDeviceBrandData {
    companyId?: string | '',
    name?: string | '',
    deviceType: IDeviceTypeData |null;
}

export { IDeviceBrandData };