import { HttpErrorResponse } from '@angular/common/http';
import { ErrorHandler, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CoreModule } from '../../core.module';
import { NotificationService } from '../notification/notification.service';

@Injectable({
    providedIn: CoreModule
})
export class ErrorHandlerService implements ErrorHandler {

    constructor(
        private readonly notificationService: NotificationService,
        private readonly router: Router
    ) {
    }

    handleError(error: Error): void {
        if (error instanceof HttpErrorResponse){
            this.handleHttpErrorResponse(error);
        } else {

        }
    }

    private handleHttpErrorResponse(errorResponse: HttpErrorResponse){
        switch (errorResponse.status){
            case 400: {
                this.notificationService.showError(errorResponse.error.title);
                break;
            }
            case 404: {
                this.router.navigateByUrl("/not-found");
                break;
            }
            default: {
                this.notificationService.showError("An unexpected server error occured")
            }
        }

        console.log(errorResponse);
    }
}
