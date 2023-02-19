import { IDeviceData } from "./DeviceData";
import { IUserData } from "./UserData";

interface IDeviceServiceData {
    linkedDeviceServiceId: string;
    deviceId: string;
    userId: string;
    userAssignDateString: string;
    name: string;
    phone: string;
    failureDateString: string;
    resultDateString: string;
    serviceBootCode: string;
    bootDescription: string;
    serviceResultCode: string;
    resultDescription: string;
    wBCount: string;
    colorCount: string;
    user: IUserData;
    device: IDeviceData;
}

export { IDeviceServiceData };