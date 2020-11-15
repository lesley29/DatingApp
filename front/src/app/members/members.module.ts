import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MemberListComponent } from './member-list/member-list.component';
import { MemberDetailsComponent } from './member-details/member-details.component';
import { MemberCardComponent } from './member-list/member-card/member-card.component';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { MembersRoutingModule } from './members-routing.module';
import { MemberService } from './services/member.service';

@NgModule({
    declarations: [
        MemberListComponent,
        MemberDetailsComponent,
        MemberCardComponent
    ],
    imports: [
        CommonModule,
        MembersRoutingModule,
        MatCardModule,
        MatButtonModule,
        MatGridListModule,
        MatIconModule,
        RouterModule
    ],
    providers: [
        MemberService
    ]
})
export class MembersModule { }
