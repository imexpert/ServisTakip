import { IDeviceBrandData } from "./DeviceBrandData";
import { IDeviceData } from "./DeviceData";
import { IDeviceModelData } from "./DeviceModelData";

interface IFirmaOzetData {
    customerId?: string | '',
    addressId?: string | '',
    customerTitle?: string | '',
    customerSectorId?: string | '',
    customerSector?: string | '',
    accountCode?: string | '',
    authorizedName?: string | '',
    authorizedPhone?: string | '',
    authorizedTask?: string | '',
    cityName?: string | '',
    authorizedEmail?: string | '',
    deviceId: string,
    districtName?: string | '',
    department?: string | '',
    quarterName?: string | '',
    regionCode?: string | '',
    contractType?: string | '',
    wbCount?: string | '',
    colorCount?: string | '',
    totalCount?: string | '',
    deviceStatus?: string | '',
    maintenanceStatus?: string | '',
    deviceModel: IDeviceModelData | null,
    deviceBrand: IDeviceBrandData | null,
    device: IDeviceData | null,
    backgroundColor?: string | '',
    maintenanceBackgroundColor?: string | '',
    contractMaintenanceStatus?: string | '',
}

export { IFirmaOzetData };