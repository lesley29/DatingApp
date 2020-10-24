import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'da-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
    title = 'front';
    users: any;

    constructor(private readonly httpClient: HttpClient) {
    }

    ngOnInit(): void {
        this.getUsers();
    }

    private getUsers() {
        this.httpClient.get('http://localhost:5001/api/users/list')
            .subscribe(
                response => {
                    this.users = response;
                },
                err => {
                    console.log(err);
                }
            );
    }
}