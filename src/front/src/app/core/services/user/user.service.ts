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
    private readonly isAuthenticatedSubject$$: BehaviorSubject<boolean>;
    private readonly currentUser$$: BehaviorSubject<IUser | null>; //= new BehaviorSubject<IUser| null>({id: 4, username: "alex@mail.ru", photoUrl: ''});

    constructor(private readonly api: ApiService) {
        const isAuthenticated = document.cookie.includes('da-a-token-existence');
        this.isAuthenticatedSubject$$ = new BehaviorSubject(isAuthenticated);

        let currentUser: IUser | null = null;

        if (isAuthenticated) {
            const serializedUser = localStorage.getItem('user');
            currentUser = serializedUser ? JSON.parse(serializedUser) : null;
        } else {
            localStorage.removeItem('user');
        }

        this.currentUser$$ = new BehaviorSubject<IUser | null>(currentUser);
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
                    this.setCurrentUser(loggedInUser);
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
                    localStorage.removeItem('user');
                })
            );
    }

    public register(request: IUserRegistrationRequest): Observable<void> {
        return this.api
            .post<IUser>("users/registration", request)
            .pipe(
                map(user => {
                    this.setCurrentUser(user);
                })
            )
    }

    private setCurrentUser(user: IUser){
        this.isAuthenticatedSubject$$.next(true);
        this.currentUser$$.next(user);
        localStorage.setItem('user', JSON.stringify(user));
    }

}
