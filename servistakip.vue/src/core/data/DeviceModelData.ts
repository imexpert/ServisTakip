import { IDeviceBrandData } from "./DeviceBrandData";

interface IDeviceModelData {
    id?: string | '',
    name?: string | '',
    deviceBrandId?: string | '',
    deviceBrand: IDeviceBrandData | null;
}

export { IDeviceModelData };