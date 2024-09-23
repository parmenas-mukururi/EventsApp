import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  loginService(data: object): Observable<any> {
    return this.http.post('https://localhost:7225/api/Auth/login', data);
  }

  getUserToken() {
    const token = localStorage.getItem('access_token');
    return token;
  }

  constructor(private http: HttpClient) {}
}
