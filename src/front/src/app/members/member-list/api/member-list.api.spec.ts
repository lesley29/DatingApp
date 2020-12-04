import { TestBed } from '@angular/core/testing';

import { MemberListApi } from './member-list.api';

describe('MemberListService', () => {
    let service: MemberListApi;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(MemberListApi);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
