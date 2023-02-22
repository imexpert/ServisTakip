import { IDeviceData } from "./DeviceData";
import { IUserData } from "./UserData";

interface IDeviceServiceData {
    id?: string | '',
    linkedDeviceServiceId?: string | '',
    deviceId?: string | '',
    userId?: string | '',
    userAssignDateString?: string | '',
    name?: string | '',
    phone?: string | '',
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
    tonerType?:string|'',
    blackCount?:string|'',
    blueCount?:string|'',
    redCount?:string|'',
    yellowCount?:string|'',
    colorCount?: string | '',
    dr?: string | '',
    bc?: string | '',
    pa?: string | '',
    bk?: string | '',
    dv?: string | '',
    fs?: string | '',
    ak?: string | '',
    user?: IUserData;
    device?: IDeviceData;
}

export { IDeviceServiceData };