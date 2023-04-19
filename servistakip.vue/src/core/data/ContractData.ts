import { IDeviceData } from "./DeviceData";

interface IContractData {
    deviceId?: Number | '',
    startDate?: string | '',
    startDateString?: string | '',
    endDate?: string | '',
    endDateString?: string | '',
    contractCode?: string | '',
    maintenancePeriod?: string | '',
    price?: string | '',
    currencyType?: string | '',
    status?: boolean | false,
    device:IDeviceData
}

export { IContractData };