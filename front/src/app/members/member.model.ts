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
    Unknown,
    Male,
    Female
}

export interface Photo {
    url: string,
    isMain: boolean
}

export interface UpdateMemberInfoRequest {
    briefDescription?: string,
    lookingFor?: string,
    interests?: string,
    city?: string,
    country?: string
}