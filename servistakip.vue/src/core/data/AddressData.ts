import { ICustomerData } from "./CustomerData";
import { IDeviceModelData } from "./DeviceModelData";
import { IQuerterData } from "./QuerterData";

interface IAddressData {
    customerId?: string | '',
    quarterId?: string | '',
    serialNumber: string | '',
    addressTitle: string | '',
    accountCode: string | '',
    netAddress?: string | '',
    authorizedName?: string | '',
    authorizedTask?: string | '',
    authorizedPhone?: string | '',
    authorizedEmail?: string | '',
    description?: string | '',
    customer?: ICustomerData | null;
    querter?: IQuerterData | null;
    deviceModel?: IDeviceModelData | null;
}

export { IAddressData };