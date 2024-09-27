import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import  {jwtDecode}  from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private userSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  public user$: Observable<any> = this.userSubject.asObservable();

  loginService(data: object): Observable<any> {
    return this.http.post('https://localhost:7225/api/Auth/login', data);
  }

  logout() {
    localStorage.removeItem('access_token');
  }
  getUserToken() {
    const token = localStorage.getItem('access_token');
    return token;
  }

  getDecodedToken(token: string | null) {
    if (token) {
      const decoded = jwtDecode(token);
      console.log(decoded);
      return decoded;
    }
    return null;
  }

  getUserInfo() {
    const token = this.getUserToken()
    const decoded = this.getDecodedToken(token);
    return decoded;
  }


  isLoggedIn() {
    return localStorage.getItem('access_token') !== null;
  }
  constructor(private http: HttpClient) {}
}
