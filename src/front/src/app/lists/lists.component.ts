import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';

@Component({
    selector: 'da-lists',
    templateUrl: './lists.component.html',
    styleUrls: ['./lists.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListsComponent implements OnInit {

    constructor() { }

    ngOnInit(): void {
    }

}
