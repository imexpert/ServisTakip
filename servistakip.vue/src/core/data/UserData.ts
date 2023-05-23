interface IUserData {
    id: string | '',
    avatar: string | null,
    firstname: string | '',
    lastname: string | '',
    email: string | '',
    gender: number | 0,
    fullname: string | '',
    admin: boolean | false,
    groups: string | '',
    lastLogin: Date | null,
}

export { IUserData }