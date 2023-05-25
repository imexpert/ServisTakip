import { UploadRawFile } from "element-plus";

interface IUserData {
    id: string | '',
    avatar: UploadRawFile | null,
    firstname: string | '',
    lastname: string | '',
    email: string | '',
    gender: number | 0,
    password: string | '',
    status: Boolean | 0,
    fullname: string | '',
    admin: boolean | false,
    groups: string | '',
    lastLogin: Date | null,
    lastLoginString: string | '',
}

export { IUserData }