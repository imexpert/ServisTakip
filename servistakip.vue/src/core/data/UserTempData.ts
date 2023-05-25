import { UploadRawFile } from "element-plus";

interface IUserTempData {
    avatar: UploadRawFile,
    firstname: string,
    lastname: string,
    email: string,
    password: string,
    gender: number,
    status: Boolean,
}

export { IUserTempData }