import { IDeviceTypeData } from "./DeviceTypeData";

interface IDeviceBrandData {
    id?: string | '',
    name?: string | undefined | '',
    deviceType: IDeviceTypeData | null;
}

export { IDeviceBrandData };