import { Guid } from 'guid-typescript';
import { apiUrl } from 'src/constants';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import PassTestViewModel from '../models/ViewModels/PassTestViewModel';
import { TestGeneral } from '../models/test/testGeneral';
import { TestSpecific } from '../models/test/testSpecific';

@Injectable()
export default class TestService {
  private readonly _testsUrl: string = `${apiUrl}/Test`;

  constructor(private http: HttpClient) {}

  getUserTests(userId: Guid): Observable<TestGeneral[]> {
    return this.http.get<TestGeneral[]>(`${this._testsUrl}/user-owned-tests`, {
      params: {
        userId: userId.toString(),
      },
    });
  }

  getTestById(testId: Guid): Observable<TestSpecific> {
    return this.http.get<TestSpecific>(`${this._testsUrl}/get-test`, {
      params: {
        testId: testId.toString(),
      },
    });
  }

  passTest(passTestViewModel: PassTestViewModel): Observable<any> {
    return this.http.post(
      `${this._testsUrl}/pass-test`,
      {
        testId: passTestViewModel.testId.toString(),
        userId: passTestViewModel.userId.toString(),
        answerIds: passTestViewModel.answerIds,
      },
      {
        responseType: 'text',
      }
    );
  }

  getMarkForTest(testId: Guid, userId: Guid): Observable<number> {
    return this.http.get<number>(`${this._testsUrl}/mark`, {
      params: {
        testId: testId.toString(),
        userId: userId.toString(),
      },
    });
  }
}
