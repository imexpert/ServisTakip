import { ICustomerData } from "./CustomerData";
import { IDeviceModelData } from "./DeviceModelData";
import { IDistrictData } from "./DistrictData";
import { IQuerterData } from "./QuerterData";

interface IAddressData {
    id?: string | '',
    customerId?: string | '',
    districtId?: string | '',
    querterName: string | '',
    regionCode: string | '',
    serialNumber: string | '',
    addressTitle: string | '',
    accountCode: string | '',
    netAddress?: string | '',
    authorizedName?: string | '',
    authorizedTask?: string | '',
    authorizedWorkPhone?: string | '',
    authorizedPhone?: string | '',
    authorizedEmail?: string | '',
    description?: string | '',
    department?: string | '',
    customer?: ICustomerData | null;
    district?: IDistrictData | null;
    deviceModel?: IDeviceModelData | null;
}

export { IAddressData };