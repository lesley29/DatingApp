import { Gender } from 'src/app/core/models/member.model';

export interface MemberSummary {
    id: number,
    name: string,
    city?: string,
    mainPhotoUrl?: string
}

export interface MemberFilter {
    gender?: Gender,
    minAge?: number,
    maxAge?: number,
    sortBy: SortableField
}

export const enum SortableField {
    LastActive = "LastActive",
    Created = "Created"
}