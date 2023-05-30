import { IDistrictData } from "./DistrictData";

interface IQuerterData {
    id?: string | '',
    name?: string | '',
    quarterId?: string | '',
    serialNumber?: string | '',
    addressTitle?: string | '',
    accountCode?: string | '',
    netAddress?: string | '',
    authorizedName?: string | '',
    authorizedTask?: string | '',
    authorizedPhone?: string | '',
    authorizedEmail?: string | '',
    description?: string | '',
    district: IDistrictData;
}

export { IQuerterData };