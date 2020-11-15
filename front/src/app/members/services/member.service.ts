import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/core/services/api/api.service';
import { Member } from '../member.model';

@Injectable()
export class MemberService {

    constructor(private readonly apiService: ApiService) {
    }

    public getList(): Observable<Member[]> {
        return this.apiService.get<Member[]>("members/list");
    }

    public get(id: number) {
        return this.apiService.get<Member>(`members/${id}`);
    }
}
