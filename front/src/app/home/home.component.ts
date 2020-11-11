import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { NotificationService } from '../core/services/notification/notification.service';

@Component({
    selector: 'da-home',
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class HomeComponent {

    constructor(private readonly notificationService: NotificationService)
    { }

    public show(){
        this.notificationService.showError("something went wrong");
    }
}
