import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Member } from 'src/app/core/models/member.model';

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

    public ngOnInit(): void {
        this.member = this.route.snapshot.data["member"];
    }

    get mainPhotoUrl(): string | undefined {
        return this.member.photos.find(ph => ph.isMain)?.url;
    }
}
