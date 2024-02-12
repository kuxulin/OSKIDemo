import { Component, OnInit } from '@angular/core';
import TestService from '../services/test.service';
import { take } from 'rxjs';
import { TestGeneral } from '../models/test/testGeneral';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-user-tests',
  templateUrl: './user-tests.component.html',
  styleUrls: ['./user-tests.component.scss'],
})
export class UserTestsComponent implements OnInit {
  tests: TestGeneral[] = [];

  constructor(
    private testService: TestService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.testService
      .getUserTests(this.authService.getUserId())
      .pipe(take(1))
      .subscribe((result) => (this.tests = result));
  }
}
