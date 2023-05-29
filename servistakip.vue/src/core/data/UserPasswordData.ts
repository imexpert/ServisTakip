import { UploadRawFile, UploadUserFile } from "element-plus";

interface IUserPasswordData {
    id: Number,
    currentPassword: string,
    password: string,
    passwordAgain: string,
}

export { IUserPasswordData }