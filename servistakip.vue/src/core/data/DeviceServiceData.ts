import { IDeviceData } from "./DeviceData";
import { IUserData } from "./UserData";

interface IDeviceServiceData {
    id?: string | null,
    linkedDeviceServiceId?: string | null,
    deviceId: number | null,
    userId?: string | '',
    userAssignDate?: string | null,
    userAssignDateString?: string | '',
    name?: string | '',
    phone?: string | '',
    failureDate?: string | '',
    failureDateString?: string | '',
    resultDateString?: string | '',
    resultDate?: string | '',
    serviceBootCode?: string | '',
    bootDescription?: string | '',
    detectionCode?: string | '',
    detectionDescription?: string | '',
    serviceResultCode?: string | '',
    resultDescription?: string | '',
    wbCount?: string | '',
    tonerType?: string | '',
    blackCount?: string | '',
    blueCount?: string | '',
    redCount?: string | '',
    yellowCount?: string | '',
    colorCount?: string | '',
    dr?: boolean | false,
    bc?: boolean | false,
    pa?: boolean | false,
    bk?: boolean | false,
    dv?: boolean | false,
    fs?: boolean | false,
    ak?: boolean | false,
    user?: IUserData | null;
    device?: IDeviceData | null;
}

export { IDeviceServiceData };