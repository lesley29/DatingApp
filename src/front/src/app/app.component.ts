import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { SpinnerService } from './core/services/spinner/spinner.service';

@Component({
    selector: 'da-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    public showSpinner$: Observable<boolean>;

    constructor(private readonly spinnerService: SpinnerService) {
        this.showSpinner$ = this.spinnerService.showSpinner$;
    }
}