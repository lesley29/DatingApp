import { HttpEvent, HttpEventType, HttpProgressEvent, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { filter, map, tap } from 'rxjs/operators';
import { ApiService } from 'src/app/core/services/api/api.service';
import { Member, Photo, UpdateMemberInfoRequest } from '../member.model';

@Injectable()
export class MemberService {

    constructor(private readonly apiService: ApiService) {
    }

    public getList(): Observable<Member[]> {
        return this.apiService.get<Member[]>("members/list");
    }

    public get(id: number): Observable<Member> {
        return this.apiService.get<Member>(`members/${id}`);
    }

    public updateCurrentUserInfo(request: UpdateMemberInfoRequest) {
        return this.apiService.put<void>('members/current/info', request);
    }

    public addPhoto(photo: File): Observable<HttpProgressEvent | HttpResponse<Photo>> {
        var formData = new FormData();
        formData.append("formFile", photo, photo.name);

        return this.apiService.postWithProgress<Photo>('members/current/photos', formData)
            .pipe(
                tap(e => console.log(e)),
                filter(this.eventIsResponseOrProgress)
            );
    }

    private eventIsResponseOrProgress<T>(e: HttpEvent<T>): e is HttpResponse<T> | HttpProgressEvent {
        return e.type === HttpEventType.Response || e.type === HttpEventType.UploadProgress;
    }
}