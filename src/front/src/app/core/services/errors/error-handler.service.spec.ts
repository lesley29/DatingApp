import { TestBed } from '@angular/core/testing';

import { DatingAppErrorHandler } from './error-handler.service';

describe('ErrorHandlerService', () => {
    let service: DatingAppErrorHandler;

    beforeEach(() => {
        TestBed.configureTestingModule({});
        service = TestBed.inject(DatingAppErrorHandler);
    });

    it('should be created', () => {
        expect(service).toBeTruthy();
    });
});
