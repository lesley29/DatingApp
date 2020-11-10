import { Component, ChangeDetectionStrategy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/user/user.service';

@Component({
    selector: 'da-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class LoginComponent {
    public loginForm = new FormGroup({
        email: new FormControl('', Validators.email),
        password: new FormControl('', Validators.required)
    });

    constructor(
        private readonly userService: UserService,
        private readonly router: Router) {
    }

    login(){
        this.userService.login({
            username: this.loginForm.get("email")?.value,
            password: this.loginForm.get("password")?.value
        })
        .subscribe(() => {
            this.router.navigateByUrl("/members");
        });
    }

}
