import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TestComponent } from './test/test.component';
import { UserTestsComponent } from './user-tests/user-tests.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path: 'tests', component: UserTestsComponent },
  { path: 'tests/:id', component: TestComponent },
  { path: 'login', component: LoginComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
