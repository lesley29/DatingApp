import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberDetailsComponent } from './member-details/member-details.component';
import { MemberCardComponent } from './member-list/member-card/member-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { MemberService } from './services/member.service';
import { MatListModule } from '@angular/material/list';
import { MatTabsModule } from '@angular/material/tabs';
import { SharedModule } from '../shared/shared.module';
import { MemberEditComponent } from './member-edit/member-edit.component';
import { MemberResolver } from './services/member.resolver';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { ReactiveFormsModule } from '@angular/forms';
import { PhotoEditorComponent } from './member-edit/photo-editor/photo-editor.component';

@NgModule({
    declarations: [
        MemberListComponent,
        MemberDetailsComponent,
        MemberCardComponent,
        MemberEditComponent,
        PhotoEditorComponent
    ],
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatIconModule,
        MatListModule,
        MatTabsModule,
        SharedModule,
        MatFormFieldModule,
        MatInputModule,
        MatProgressBarModule,
        ReactiveFormsModule,
        RouterModule
    ],
    providers: [
        MemberService,
        MemberResolver
    ]
})
export class MembersModule { }
