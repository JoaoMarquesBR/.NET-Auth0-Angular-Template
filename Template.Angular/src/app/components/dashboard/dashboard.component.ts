import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { AuthService, User } from '@auth0/auth0-angular';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent {

  constructor(@Inject(DOCUMENT) public document: Document, public auth: AuthService, private http: HttpClient) {}

  publicEndpoint(){
    this.http
    .post<any>(
      'https://localhost:7013/api/Auth/Public',
      {},
    )
    .subscribe((response) => {
      console.log(response);
    });
  }

  authEndpoint() {
    this.auth.idTokenClaims$.subscribe((idToken) => {
      if (idToken && idToken.__raw) {
        this.auth.user$.subscribe(user => {
          const headers = new HttpHeaders({
            'Authorization': `Bearer ${idToken.__raw}`
          });

          this.http.post<any>('https://localhost:7013/api/Auth/AuthTest', {}, { headers }).subscribe(
            (response) => {
              console.log(response);
            },
            (error) => {
              console.error('Error calling API:', error);
            }
          );
        });
      } else {
        console.error('idToken is null or undefined.');
      }
    });
  }

}
