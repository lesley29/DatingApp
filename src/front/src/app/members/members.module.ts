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
import { MemberResolver } from './services/member.resolver';
import { MembersRoutingModule } from './members-routing.module';
import { MatPaginatorModule } from '@angular/material/paginator';

@NgModule({
    declarations: [
        MemberListComponent,
        MemberDetailsComponent,
        MemberCardComponent
    ],
    imports: [
        CommonModule,
        MatCardModule,
        MatButtonModule,
        MatIconModule,
        MatListModule,
        MatTabsModule,
        SharedModule,
        MembersRoutingModule,
        MatPaginatorModule,
        RouterModule
    ],
    providers: [
        MemberService,
        MemberResolver
    ]
})
export class MembersModule { }
