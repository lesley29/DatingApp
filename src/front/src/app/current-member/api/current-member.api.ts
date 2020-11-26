import { HttpEvent, HttpEventType, HttpProgressEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { filter, finalize, map, tap } from 'rxjs/operators';
import { CoreModule } from 'src/app/core/core.module';
import { Member, Photo } from 'src/app/core/models/member.model';
import { ApiService } from 'src/app/core/services/api/api.service';
import { UserService } from 'src/app/core/services/user/user.service';
import { UpdateMemberInfoRequest } from '../models/current-member.model';

@Injectable({
    providedIn: CoreModule
})
export class CurrentMemberApi {
    private readonly currentMemberId: number;
    private readonly photoUploadingProgress$ = new Subject<number | null>();

    constructor(
        private readonly api: ApiService,
        private readonly userService: UserService
    ) {
        this.currentMemberId = this.userService.getCurrentUser()!.id;
    }

    public get(): Observable<Member> {
        return this.api.get<Member>(`members/${this.currentMemberId}`);
    }

    public getPhotoUploadingProgress(): Observable<number | null> {
        return this.photoUploadingProgress$.asObservable();
    }

    public uploadPhoto(photo: File): Observable<Photo | null> {
        var formData = new FormData();
        formData.append("formFile", photo, photo.name);

        return this.api.postWithProgress<Photo>('members/current/photos', formData)
            .pipe(
                tap(e => {
                    if (e.type === HttpEventType.UploadProgress){
                        this.photoUploadingProgress$.next(Math.round(e.loaded * 100 / e.total!));
                    }
                }),
                filter(this.eventIsResponse),
                map(response => {
                    return response.body;
                }),
                finalize(() => {
                    this.photoUploadingProgress$.next(null)
                })
            );
    }

    public updateMemberInfo(request: UpdateMemberInfoRequest): Observable<void> {
        return this.api.put<void>('members/current/info', request);
    }

    public setMainPhoto(photoName: string): Observable<void> {
        return this.api.put(`members/current/photos/${photoName}/main`);
    }

    public deletePhoto(photoName: string): Observable<void> {
        return this.api.delete(`members/current/photos/${photoName}`);
    }

    private eventIsResponse<T>(e: HttpEvent<T>): e is HttpResponse<T> {
        return e.type === HttpEventType.Response;
    }
}