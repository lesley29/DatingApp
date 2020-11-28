import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
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
    public readonly defaultPageSize = 12;

    public members$: Observable<MemberSummary[]>;
    public totalMemberCount$: Observable<number>;

    public pageSizes = [this.defaultPageSize, 18];

    constructor(private readonly memberListService: MemberListService) {
        this.members$ = this.memberListService.getMembers();
        this.totalMemberCount$ = this.memberListService.getTotalCount();
    }

    public ngOnInit(): void {
        this.memberListService.loadMembers(0, this.defaultPageSize);
    }

    public onPageChange(event: PageEvent) {
        this.memberListService.loadMembers(event.pageIndex, event.pageSize);
    }
}
