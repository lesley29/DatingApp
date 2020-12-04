import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Member } from 'src/app/core/models/member.model';
import { PresenceService } from 'src/app/core/services/presence/presence.service';

@Component({
    selector: 'da-member-details',
    templateUrl: './member-details.component.html',
    styleUrls: ['./member-details.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberDetailsComponent implements OnInit {
    public member!: Member;
    public online$: Observable<boolean>;

    constructor(
        private readonly route: ActivatedRoute,
        private readonly presenceService: PresenceService
    ) {
        this.online$ = presenceService.getOnlineUsers()
            .pipe(
                map(onlineMembers => !!onlineMembers.includes(this.member.id))
            );
    }

    public ngOnInit(): void {
        this.member = this.route.snapshot.data["member"];
    }

    get mainPhotoUrl(): string | undefined {
        return this.member.photos.find(ph => ph.isMain)?.url;
    }
}
