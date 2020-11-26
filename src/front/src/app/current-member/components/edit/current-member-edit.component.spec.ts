import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentMemberEditComponent } from './current-member-edit.component';

describe('CurrentMemberEditComponent', () => {
    let component: CurrentMemberEditComponent;
    let fixture: ComponentFixture<CurrentMemberEditComponent>;

    beforeEach(async () => {
        await TestBed.configureTestingModule({
            declarations: [ CurrentMemberEditComponent ]
        })
        .compileComponents();
    });

    beforeEach(() => {
        fixture = TestBed.createComponent(CurrentMemberEditComponent);
        component = fixture.componentInstance;
        fixture.detectChanges();
    });

    it('should create', () => {
        expect(component).toBeTruthy();
    });
});
