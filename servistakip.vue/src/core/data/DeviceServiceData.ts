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
    serviceBootCode?: string | '',
    bootDescription?: string | '',
    detectionCode?: string | '',
    detectionDescription?: string | '',
    serviceResultCode?: string | '',
    resultDescription?: string | '',
    wBCount?: string | '',
    colorCount?: string | '',
    user?: IUserData;
    device?: IDeviceData;
}

export { IDeviceServiceData };