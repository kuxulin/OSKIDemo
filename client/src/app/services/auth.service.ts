import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiUrl } from '../../constants';
import { Observable } from 'rxjs';
import { jwtDecode } from 'jwt-decode';
import { Guid } from 'guid-typescript';

@Injectable()
export class AuthService {
  private readonly _authUrl = `${apiUrl}/Auth`;
  constructor(private http: HttpClient) {}

  signIn(login: string, password: string) {
    return this.http.post<object>(`${this._authUrl}/login`, {
      login: login,
      password: password,
    });
  }

  getToken(): string | undefined {
    const token = localStorage.getItem('token') || undefined;

    return token;
  }

  setToken(result: any) {
    let decodedToken: any = jwtDecode(result.token);
    localStorage.setItem('userId', decodedToken.userId);
    localStorage.setItem('token', result.token);
  }

  isTokenExpired(): boolean {
    const token = this.getToken();
    if (!token) return false;

    let decodedToken: any = jwtDecode(token);
    if (decodedToken.exp * 1000 >= Date.now()) return false;

    return true;
  }

  getUserId(): Guid {
    return Guid.parse(localStorage.getItem('userId')!);
  }

  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userId');
  }
}
