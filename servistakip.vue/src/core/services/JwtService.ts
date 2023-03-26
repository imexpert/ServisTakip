const ID_TOKEN_KEY = 'id_token' as string;
const FULL_NAME = 'full_name' as string;
const EMAIL = 'email' as string;
const ISADMIN = 'isAdmin' as string;
const GENDER = 'gender' as string;
const AVATAR = 'avatar' as string;

/**
 * @description get token form localStorage
 */
export const getToken = (): string | null => {
  return window.localStorage.getItem(ID_TOKEN_KEY);
};

/**
 * @description get fullname form localStorage
 */
export const isAdmin = (): string | null => {
  return window.localStorage.getItem(ISADMIN);
};

/**
 * @description get fullname form localStorage
 */
export const getFullName = (): string | null => {
  return window.localStorage.getItem(FULL_NAME);
};

/**
 * @description get email form localStorage
 */
export const getEmail = (): string | null => {
  return window.localStorage.getItem(EMAIL);
};

/**
 * @description get gender form localStorage
 */
export const getGender = (): string | null => {
  return window.localStorage.getItem(GENDER);
};

/**
 * @description get avatar form localStorage
 */
export const getAvatar = (): string | null => {
  return window.localStorage.getItem(AVATAR);
};

/**
 * @description save token into localStorage
 * @param token: string
 */
export const saveToken = (token: string): void => {
  window.localStorage.setItem(ID_TOKEN_KEY, token);
};

/**
 * @description save FullName
 * @param fullName: string
 */
export const saveFullName = (fullName: string): void => {
  window.localStorage.setItem(FULL_NAME, fullName);
};

/**
 * @description save Email
 * @param fullName: string
 */
export const saveEmail = (email: string): void => {
  window.localStorage.setItem(EMAIL, email);
};

/**
 * @description save IsAdmin
 * @param fullName: string
 */
export const saveIsAdmin = (isAdmin: string): void => {
  window.localStorage.setItem(ISADMIN, isAdmin);
};

/**
 * @description save Gender
 * @param fullName: string
 */
export const saveGender = (gender: string): void => {
  window.localStorage.setItem(GENDER, gender);
};

/**
 * @description save Avatar
 * @param fullName: string
 */
export const saveAvatar = (avatar: string): void => {
  window.localStorage.setItem(AVATAR, avatar);
};

/**
 * @description remove token form localStorage
 */
export const destroyToken = (): void => {
  window.localStorage.removeItem(ID_TOKEN_KEY);
};

export default
  {
    getToken,
    saveToken,
    destroyToken,
    getFullName,
    getEmail,
    saveEmail,
    saveFullName,
    saveIsAdmin,
    isAdmin,
    getGender,
    getAvatar,
    saveGender,
    saveAvatar
  };
