import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/core/services/user/user.service';

@Component({
    selector: 'da-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class SignupComponent {
    public registerForm = new FormGroup({
        email: new FormControl('', Validators.email),
        password: new FormControl('', Validators.required)
    });

    constructor(private readonly userService: UserService) { }

    public register() {
        this.userService.register({
            username: this.registerForm.get("email")?.value,
            password: this.registerForm.get("password")?.value
        })
        .subscribe(response => {
            console.log(response);
        });
    }
}
