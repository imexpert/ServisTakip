import { IAddressData } from "./AddressData";

interface IDeviceData {
    addressId: string;
    deviceModelId: string;
    serialNumber: string;
    assemblyDateString: string;
    description: string;
    status: string;
    address: IAddressData;
    deviceModel: IDeviceData;
}

export { IDeviceData };