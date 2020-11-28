export interface Member {
    id: number,
    name: string,
    dateOfBirth: Date,
    gender: Gender,
    knownAs?: string,
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