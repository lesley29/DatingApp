import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PageEvent } from '@angular/material/paginator';
import { Observable } from 'rxjs';
import { finalize } from 'rxjs/operators';
import { MemberFilter, MemberSummary } from './member-list.model';
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
    public filter: MemberFilter = {};

    public members$: Observable<MemberSummary[]>;
    public totalMemberCount$: Observable<number>;

    public pageSizes = [this.defaultPageSize, 18];

    private currentPageSize = this.defaultPageSize;

    constructor(private readonly memberListService: MemberListService) {
        this.members$ = this.memberListService.getMembers();
        this.totalMemberCount$ = this.memberListService.getTotalCount();
    }

    public ngOnInit(): void {
        this.memberListService.loadMembers(0, this.defaultPageSize, this.filter);
    }

    public onPageChange(event: PageEvent) {
        this.currentPageSize = event.pageSize;
        this.memberListService.loadMembers(event.pageIndex, event.pageSize, this.filter);
    }

    public onFilterChange(filter: MemberFilter) {
        this.filter = filter;
        this.memberListService.loadMembers(0, this.currentPageSize, this.filter);
    }
}
