import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { IUser } from 'src/app/core/services/user/user.model';
import { UserService } from 'src/app/core/services/user/user.service';
import { Member } from '../member.model';
import { MemberService } from '../services/member.service';

@Component({
    selector: 'da-member-edit',
    templateUrl: './member-edit.component.html',
    styleUrls: ['./member-edit.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberEditComponent implements OnInit {
    public member$!: Observable<Member>;
    public form: FormGroup;

    private user: IUser | undefined;

    constructor(
        private readonly userService: UserService,
        private readonly memberService: MemberService,
        private readonly formBuilder: FormBuilder
    ) {
        this.userService.currentUser$
            .pipe(first())
            .subscribe(user => {
                this.user = user!;
            });

        this.form = this.createForm();
    }

    public ngOnInit(): void {
        this.member$ = this.memberService.get(this.user!.id);
    }

    public onSubmit(): void {
        console.log("Submitted!");
    }

    private createForm(): FormGroup {
        return this.formBuilder.group({
            description: this.formBuilder.control(''),
            lookingFor: this.formBuilder.control(''),
            interests: this.formBuilder.control(''),
            locationDetails: this.formBuilder.group({
                city: this.formBuilder.control(''),
                country: this.formBuilder.control('')
            })
        });
    }
}
