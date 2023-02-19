import { IDeviceTypeData } from "./DeviceTypeData";

interface IDeviceBrandData {
    name?: string | '',
    deviceType: IDeviceTypeData;
}

export { IDeviceBrandData };