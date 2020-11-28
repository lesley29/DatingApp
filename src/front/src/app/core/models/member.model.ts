export interface Member {
    id: number,
    email: string,
    dateOfBirth: string,
    gender: Gender,
    name: string,
    about?: string,
    city?: string,
    country?: string,
    photos: Photo[],
    created: Date,
    lastActive: Date
}

export const enum Gender {
    Male,
    Female
}

export interface Photo {
    name: string,
    url: string,
    isMain: boolean
}