import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './auth/login/login.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthGuard } from './core/guards/auth/auth.guard';
import { PreventUnsavedFormChangesGuard } from './core/guards/prevent-unsaved-changes/prevent-unsaved-form-changes.guard';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailsComponent } from './members/member-details/member-details.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MemberResolver } from './members/services/member.resolver';
import { MessagesComponent } from './messages/messages.component';
import { NotFoundComponent } from './shared/not-found/not-found.component';

const routes: Routes = [
    {
        path: "",
        component: HomeComponent,
        pathMatch: "full"
    },
    {
        path: "login",
        component: LoginComponent
    },
    {
        path: "signup",
        component: SignupComponent
    },
    {
        path: "",
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {
                path: "members",
                component: MemberListComponent,
            },
            {
                path: "members/:id",
                component: MemberDetailsComponent,
                resolve: {
                    member: MemberResolver
                }
            },
            {
                path: "member/edit",
                component: MemberEditComponent,
                canDeactivate: [PreventUnsavedFormChangesGuard]
            },
            {
                path: "lists",
                component: ListsComponent
            },
            {
                path: "messages",
                component: MessagesComponent
            },
        ]
    },
    {
        path: "not-found",
        component: NotFoundComponent
    },
    {
        path: "**",
        component: NotFoundComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes,
        {
            relativeLinkResolution: 'legacy'
        })
    ],
    exports: [RouterModule],
    providers: [PreventUnsavedFormChangesGuard]
})
export class AppRoutingModule { }
