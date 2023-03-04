import { IDeviceData } from "./DeviceData";
import { IUserData } from "./UserData";

interface IDeviceServiceData {
    id?: string | null,
    linkedDeviceServiceId?: string | null,
    deviceId?: string | null,
    userId?: string | '',
    userAssignDate?: string | null,
    userAssignDateString?: string | '',
    name?: string | '',
    phone?: string | '',
    failureDate?: string | '',
    failureDateString?: string | '',
    resultDateString?: string | '',
    resultDate?: Date | '',
    serviceBootCode?: string | '',
    bootDescription?: string | '',
    detectionCode?: string | '',
    detectionDescription?: string | '',
    serviceResultCode?: string | '',
    resultDescription?: string | '',
    wBCount?: string | '',
    tonerType?: string | '',
    blackCount?: string | '',
    blueCount?: string | '',
    redCount?: string | '',
    yellowCount?: string | '',
    colorCount?: string | '',
    dr?: string | '',
    bc?: string | '',
    pa?: string | '',
    bk?: string | '',
    dv?: string | '',
    fs?: string | '',
    ak?: string | '',
    user?: IUserData | null;
    device?: IDeviceData | null;
}

export { IDeviceServiceData };