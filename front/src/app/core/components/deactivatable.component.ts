import { Component, HostListener } from '@angular/core';

@Component({
    template: ''
})
export abstract class DeactivatableComponent {
    abstract canDeactivate(): boolean;

    @HostListener('window:beforeunload', ['$event'])
    unloadNotification(event: BeforeUnloadEvent): void {
        if (this.canDeactivate()) {
            event.returnValue = true;
        } else {
            event.returnValue = false;
        }
    }
}