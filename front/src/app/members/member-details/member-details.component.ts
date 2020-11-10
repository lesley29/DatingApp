import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
    selector: 'da-member-details',
    templateUrl: './member-details.component.html',
    styleUrls: ['./member-details.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberDetailsComponent implements OnInit {

    constructor() { }

    ngOnInit(): void {
    }

}
