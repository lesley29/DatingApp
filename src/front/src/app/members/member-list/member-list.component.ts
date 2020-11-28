import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { Observable } from 'rxjs';
import { MemberSummary } from './member-list.model';
import { MemberListService } from './services/member-list.service';

@Component({
    selector: 'da-member-list',
    templateUrl: './member-list.component.html',
    styleUrls: ['./member-list.component.css'],
    providers: [MemberListService],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberListComponent implements OnInit {
    public members$: Observable<MemberSummary[]>;

    private readonly pageSize = 12;

    constructor(private readonly memberListService: MemberListService) {
        this.members$ = this.memberListService.getMembers();
    }

    ngOnInit(): void {
        this.memberListService.loadMembers(0, this.pageSize);
    }

}
