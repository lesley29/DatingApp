export interface IUserLoginRequest {
    username: string,
    password: string
}

export interface IUser {
    id: number,
    username: string,
    photoUrl: string
}

export interface IUserRegistrationRequest {
    username: string,
    password: string
}