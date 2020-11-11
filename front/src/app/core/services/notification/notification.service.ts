import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CoreModule } from '../../core.module';

@Injectable({
    providedIn: CoreModule
})
export class NotificationService {
    private readonly defaultDurationMilliseconds = 3000;

    constructor(private readonly snackService: MatSnackBar) { }

    public showError(message: string){
        this.snackService.open(message, undefined, {
            duration: this.defaultDurationMilliseconds,
            panelClass: "snack-error"
        })
    }
}
