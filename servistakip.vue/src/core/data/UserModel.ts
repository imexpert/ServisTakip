import { UploadRawFile, UploadUserFile } from "element-plus";
import { IUserTempData } from "./UserTempData";

interface IUserModel {
    file: UploadUserFile,
    userItem: IUserTempData,
}

export { IUserModel }