import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { PagedResponse } from 'src/app/core/models/pagination.model';
import { ApiService } from 'src/app/core/services/api/api.service';
import { MemberFilter, MemberSummary } from '../member-list.model';

@Injectable()
export class MemberListService {
    private readonly members$ = new BehaviorSubject<MemberSummary[]>([]);
    private readonly totalCount$ = new BehaviorSubject<number>(0);

    constructor(private readonly api: ApiService) { }

    public getMembers(): Observable<MemberSummary[]> {
        return this.members$.asObservable();
    }

    public getTotalCount(): Observable<number> {
        return this.totalCount$.asObservable();
    }

    public loadMembers(pageNumber: number, pageSize: number, filter: MemberFilter) {
        let params = new HttpParams()
            .set('pageSize', pageSize.toString())
            .set('pageNumber', pageNumber.toString())
            .set('orderBy', filter.sortBy);

        if (filter.gender) {
            params = params.append('gender', filter.gender.toString());
        }

        if (filter.minAge) {
            params = params.append('minAge', filter.minAge.toString());
        }

        if (filter.maxAge) {
            params = params.append('maxAge', filter.maxAge.toString());
        }

        this.api.get<PagedResponse<MemberSummary>>("members/list", params)
            .subscribe(response => {
                this.members$.next(response.items);
                this.totalCount$.next(response.totalCount);
            });
    }

    public like(targetUserId: number): Observable<void> {
        return this.api.put(`members/${targetUserId}/likes`);
    }
}
