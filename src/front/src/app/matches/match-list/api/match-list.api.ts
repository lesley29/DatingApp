import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiService } from 'src/app/core/services/api/api.service';
import { MemberSummary } from 'src/app/members/member-list/member-list.model';
import { LikeType } from '../../matches.model';

@Injectable()
export class MatchListApi {
    constructor(
        private readonly api: ApiService
    ) {
    }

    public getLikes(type: LikeType) {
        var params = new HttpParams()
            .append("likeType", type);

        return this.api.get<MemberSummary[]>("members/current/likes", params);
    }
}