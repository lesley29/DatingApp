import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { Member } from '../member.model';
import { MemberService } from '../services/member.service';

@Component({
    selector: 'da-member-list',
    templateUrl: './member-list.component.html',
    styleUrls: ['./member-list.component.css'],
    providers: [MemberService],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberListComponent implements OnInit {
    public members$: Observable<Member[]>;

    constructor(private readonly memberService: MemberService) {
        this.members$ = this.memberService.getList();
    }

    ngOnInit(): void {
    }

}
