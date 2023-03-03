import { IDeviceData } from "./DeviceData";

interface IContractData {
    deviceId?: string | '',
    startDate?: string | '',
    startDateString?: string | '',
    endDate?: string | '',
    endDateString?: string | '',
    contractCode?: string | '',
    maintenancePeriod?: string | '',
    status?: boolean | false,
    device:IDeviceData
}

export { IContractData };