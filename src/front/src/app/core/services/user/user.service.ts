import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { CoreModule } from '../../core.module';
import { ApiService } from '../api/api.service';
import { IUserLoginRequest, IUser, IUserRegistrationRequest } from './user.model';

@Injectable({
    providedIn: CoreModule
})
export class UserService {
    private readonly isAuthenticatedSubject$$ = new BehaviorSubject<boolean>(true);
    private readonly currentUser$$ = new BehaviorSubject<IUser| null>({id: 8, username: "vasya"});

    constructor(private readonly api: ApiService) {
    }

    public get isAuthenticated$(): Observable<boolean> {
        return this.isAuthenticatedSubject$$.asObservable();
    }

    public get currentUser$(): Observable<IUser | null> {
        return this.currentUser$$.asObservable();
    }

    public login(request: IUserLoginRequest): Observable<void> {
        return this.api
            .post<IUser>("users/login", request)
            .pipe(
                map(loggedInUser => {
                    this.isAuthenticatedSubject$$.next(true);
                    this.currentUser$$.next(loggedInUser!);
                })
            )
    }

    public logout(): Observable<void> {
        return this.api
            .post("users/logout")
            .pipe(
                map(() => {
                    this.isAuthenticatedSubject$$.next(false);
                    this.currentUser$$.next(null);
                    return;
                })
            );
    }

    public register(request: IUserRegistrationRequest): Observable<void> {
        return this.api
            .post("users/registration", request)
            .pipe(
                map(() => {
                    // this.isAuthenticatedSubject$$.next(true);
                })
            )
    }
}
