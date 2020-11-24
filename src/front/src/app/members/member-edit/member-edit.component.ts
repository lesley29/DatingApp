import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Observable } from 'rxjs';
import { first } from 'rxjs/operators';
import { FormDeactivatableComponent } from 'src/app/core/components/form-deactivatable.component';
import { NotificationService } from 'src/app/core/services/notification/notification.service';
import { IUser } from 'src/app/core/services/user/user.model';
import { UserService } from 'src/app/core/services/user/user.service';
import { Member, UpdateMemberInfoRequest } from '../member.model';
import { MemberService } from '../services/member.service';

@Component({
    selector: 'da-member-edit',
    templateUrl: './member-edit.component.html',
    styleUrls: ['./member-edit.component.css'],
    changeDetection: ChangeDetectionStrategy.OnPush
})
export class MemberEditComponent extends FormDeactivatableComponent implements OnInit {
    public member$!: Observable<Member>;
    public memberForm: FormGroup;

    private user: IUser | undefined;

    constructor(
        private readonly userService: UserService,
        private readonly memberService: MemberService,
        private readonly notificationService: NotificationService,
        private readonly formBuilder: FormBuilder
    ) {
        super();

        this.userService.currentUser$
            .pipe(first())
            .subscribe(user => {
                this.user = user!;
            });

        this.memberForm = this.createForm();
    }

    get form(): FormGroup {
        return this.memberForm;
    }

    public ngOnInit(): void {
        this.member$ = this.memberService.get(this.user!.id);
    }

    public onSubmit(): void {
        const updateRequest = this.formValueToUpdateRequest();

        this.memberService.updateCurrentUserInfo(updateRequest)
            .subscribe(() => {
                this.notificationService.showSuccess("Submitted!");
                this.form.reset(this.form.value);
            });
    }

    private formValueToUpdateRequest(): UpdateMemberInfoRequest {
        return {
            briefDescription: this.memberForm.get('description')?.value,
            lookingFor: this.memberForm.get('lookingFor')?.value,
            interests: this.memberForm.get('interests')?.value,
            city: this.memberForm.get('locationDetails.city')?.value,
            country: this.memberForm.get('locationDetails.country')?.value
        };
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
