import { Component, OnInit, ChangeDetectionStrategy, Input, Output, EventEmitter } from '@angular/core';
import { MemberSummary } from '../member-list.model';

@Component({
    selector: 'da-member-card',
    templateUrl: './member-card.component.html',
    styleUrls: ['./member-card.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberCardComponent implements OnInit {
    @Input()
    public member!: MemberSummary;

    @Output()
    public memberLike = new EventEmitter<void>();

    constructor() { }

    ngOnInit(): void {
    }

    public onMemberLikeClick() {
        this.memberLike.emit();
    }
}
