import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { EMPTY, Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable()
export class InterceptService implements HttpInterceptor {
  constructor(public router: Router, private auth: AuthService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    const token = this.auth.getToken();

    if (token && this.auth.isTokenExpired()) {
      this.auth.logout();
      this.router.navigate(['/login']);
      return EMPTY;
    }

    request = request.clone({
      setHeaders: {
        Authorization: token ? `Bearer ${token}` : '',
      },
    });

    return next.handle(request);
  }
}
