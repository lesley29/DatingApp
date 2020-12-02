import { Component, OnInit, ChangeDetectionStrategy, Input } from '@angular/core';
import { MemberSummary } from 'src/app/members/member-list/member-list.model';

@Component({
    selector: 'da-like-card',
    templateUrl: './like-card.component.html',
    styleUrls: ['./like-card.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LikeCardComponent {
    @Input()
    public likedMember!: MemberSummary;

}
