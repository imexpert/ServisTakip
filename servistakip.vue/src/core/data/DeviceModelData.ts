import { IDeviceBrandData } from "./DeviceBrandData";

interface IDeviceModelData {
    name?: string | '',
    deviceBrandId?: string | '',
    deviceBrand: IDeviceBrandData | null;
}

export { IDeviceModelData };