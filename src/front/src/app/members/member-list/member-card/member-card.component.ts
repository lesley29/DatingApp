import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { MemberSummary } from '../member-list.model';

@Component({
    selector: 'da-member-card',
    templateUrl: './member-card.component.html',
    styleUrls: ['./member-card.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberCardComponent implements OnInit {
    @Input()
    member!: MemberSummary;

    constructor() { }

    ngOnInit(): void {
    }

}
