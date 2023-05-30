import { ICityData } from "./CityData";

interface IDistrictData {
    id?: string | '',
    name?: string | '',
    city: ICityData;
}

export { IDistrictData };