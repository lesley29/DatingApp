import { BrowserModule } from '@angular/platform-browser';
import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { AuthModule } from './auth/auth.module';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { MembersModule } from './members/members.module';
import { ListsModule } from './lists/lists.module';
import { MessagesModule } from './messages/messages.module';
import { ErrorHandlerService } from './core/services/errors/error-handler.service';

@NgModule({
    declarations: [
        AppComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        CoreModule,
        SharedModule,
        AuthModule,
        HomeModule,
        MembersModule,
        ListsModule,
        MessagesModule
    ],
    providers: [
        {
            provide: ErrorHandler,
            useClass: ErrorHandlerService
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }