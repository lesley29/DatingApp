import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from '../member.model';

@Component({
    selector: 'da-member-details',
    templateUrl: './member-details.component.html',
    styleUrls: ['./member-details.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberDetailsComponent implements OnInit {
    public member!: Member;

    constructor(
        private readonly route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        this.member = this.route.snapshot.data["member"];
    }

}