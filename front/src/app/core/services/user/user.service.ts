import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CoreModule } from '../../core.module';
import { ApiService } from '../api/api.service';
import { IUserLoginRequest, IUserLoginResponse, IUserRegistrationRequest } from './user.model';

@Injectable({
    providedIn: CoreModule
})
export class UserService {
    private readonly isAuthenticatedSubject = new BehaviorSubject<boolean>(false);

    constructor(private readonly api: ApiService) {
    }

    public get isAuthenticated$(): Observable<boolean> {
        return this.isAuthenticatedSubject.asObservable();
    }

    public login(request: IUserLoginRequest): Observable<IUserLoginResponse | null> {
        return this.api
            .post<IUserLoginResponse>("users/login", request)
            .pipe(
                map(response => {
                    this.isAuthenticatedSubject.next(true);
                    return response.body;
                })
            )
    }

    public logout(): Observable<void> {
        return this.api
            .post("users/logout")
            .pipe(
                map(() => {
                    this.isAuthenticatedSubject.next(false);
                    return;
                })
            );
    }

    public register(request: IUserRegistrationRequest): Observable<void> {
        return this.api
            .post("users/registration", request)
            .pipe(
                map(() => {
                    this.isAuthenticatedSubject.next(true);
                    return;
                })
            )
    }
}
