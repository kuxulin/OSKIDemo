import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TestComponent } from './test/test.component';
import TestService from './services/test.service';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { UserTestsComponent } from './user-tests/user-tests.component';
import { LoginComponent } from './login/login.component';
import { AuthService } from './services/auth.service';
import { FormsModule } from '@angular/forms';
import { InterceptService } from './services/intercept.service';

@NgModule({
  declarations: [
    AppComponent,
    TestComponent,
    UserTestsComponent,
    LoginComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, FormsModule],
  providers: [
    TestService,
    AuthService,
    InterceptService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
