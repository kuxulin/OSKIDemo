import { Component } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { take } from 'rxjs';
import { jwtDecode } from 'jwt-decode';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-loginregister',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  login: string = '';
  password: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  signIn() {
    if (!this.checkFields()) return;

    this.authService
      .signIn(this.login, this.password)
      .pipe(take(1))
      .subscribe({
        next: (result: any) => {
          this.authService.setToken(result);
          this.errorMessage = '';
          this.router.navigate(['tests']);
        },
        error: (errorObject: HttpErrorResponse) => {
          this.errorMessage = errorObject.error;
        },
      });
  }

  checkFields(): boolean {
    return this.login.length > 0 && this.password.length > 0;
  }
}
