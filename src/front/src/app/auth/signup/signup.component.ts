import { Component, ChangeDetectionStrategy } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Gender } from 'src/app/core/models/member.model';
import { UserService } from 'src/app/core/services/user/user.service';
import { SignupFormService } from './form/services/signup-form.service';

@Component({
    selector: 'da-signup',
    templateUrl: './signup.component.html',
    styleUrls: ['./signup.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush,
    providers: [
        SignupFormService
    ]
})
export class SignupComponent {
    public registerForm: FormGroup;
    public readonly maleGender = Gender.Male;
    public readonly femaleGender = Gender.Female;

    constructor(
        private readonly userService: UserService,
        private readonly signupFormService: SignupFormService
    ) {
        this.registerForm = this.signupFormService.getForm();
    }

    public get emailHasErrors(): boolean {
        return this.signupFormService.emailHasErrors();
    }

    public get emailError(): string | null {
        return this.signupFormService.getEmailError();
    }

    public get nameHasErrors(): boolean {
        return this.signupFormService.nameHasErrors();
    }

    public get nameError(): string | null {
        return this.signupFormService.getNameError();
    }

    public get dateOfBirthHasErrors(): boolean {
        return this.signupFormService.dateOfBirthHasErrors();
    }

    public get dateOfBirthError(): string | null {
        return this.signupFormService.getDateOfBirthError();
    }

    public get passwordHasErrors(): boolean {
        return this.signupFormService.passwordHasErrors();
    }

    public get passwordError(): string | null {
        return this.signupFormService.getPasswordError();
    }

    public get passwordConfirmationHasErrors(): boolean {
        return this.signupFormService.passwordConfirmationHasErrors();
    }

    public get passwordConfirmationError(): string | null {
        return this.signupFormService.getPasswordConfirmationError();
    }

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
