import { UploadRawFile, UploadUserFile } from "element-plus";

interface IUserTempData {
    id: Number,
    avatar: string | null,
    firstname: string,
    lastname: string,
    email: string,
    password: string,
    gender: number,
    status: Boolean,
    groups: Array<Number>
}

export { IUserTempData }