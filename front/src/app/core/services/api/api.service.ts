import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CoreModule } from '../../core.module';

@Injectable({
    providedIn: CoreModule
})
export class ApiService {
    private readonly baseUrl = "http://localhost:5001/api";

    constructor(private readonly httpClient: HttpClient) {
    }

    public get<T>(path: string, params: HttpParams | undefined = undefined): Observable<HttpResponse<T>> {
        return this.httpClient.get<T>(
            this.getFullUrl(path),
            {
                params: params,
                observe: "response"
            }
        );
    }

    public post<T>(path: string, body: Object = {}): Observable<HttpResponse<T>> {
        return this.httpClient.post<T>(
            this.getFullUrl(path),
            body,
            {
                observe: "response"
            }
        )
    }

    private getFullUrl(url: string): string {
        return this.baseUrl + "/" + url;
    }
}
