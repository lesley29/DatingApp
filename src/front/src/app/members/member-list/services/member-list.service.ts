import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { Member } from 'src/app/core/models/member.model';
import { PagedResponse } from 'src/app/core/models/pagination.model';
import { ApiService } from 'src/app/core/services/api/api.service';
import { MemberSummary } from '../member-list.model';

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

    public loadMembers(pageNumber: number, pageSize: number) {
        const params = new HttpParams()
            .set('pageSize', pageSize.toString())
            .set('pageNumber', pageNumber.toString());

        this.api.get<PagedResponse<MemberSummary>>("members/list", params)
            .subscribe(response => {
                this.members$.next(response.items);
                this.totalCount$.next(response.totalCount);
            });
    }
}
