import { Component, OnInit } from '@angular/core';
import Question from '../models/question';
import TestService from '../services/test.service';
import { Guid } from 'guid-typescript';
import { take } from 'rxjs';
import { TestSpecific } from '../models/test/testSpecific';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
})
export class TestComponent implements OnInit {
  test: TestSpecific = new TestSpecific();
  answerIds: Guid[] = [];

  constructor(
    private testService: TestService,
    private route: ActivatedRoute,
    private router: Router,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    let testId = Guid.createEmpty();
    this.route.params.pipe(take(1)).subscribe((params) => {
      testId = Guid.parse(params['id']);
    });
    this.testService
      .getTestById(testId)
      .pipe(take(1))
      .subscribe((result) => (this.test = result));
  }

  answerQuestion(question: Question, answerId: Guid) {
    if (!question.isAnswered) question.isAnswered = true;

    question.currentAnswerId = answerId;
  }

  isAllQuestionsAnswered(): boolean {
    if (this.test?.questions.every((q) => q.isAnswered === true)) return true;
    else return false;
  }

  submitTest(): void {
    this.answerIds = this.test.questions.map((q) => q.currentAnswerId);
    this.testService
      .passTest({
        testId: this.test.id,
        userId: this.authService.getUserId(),
        answerIds: this.answerIds,
      })
      .pipe(take(1))
      .subscribe({
        next: () => {
          this.router.navigate(['tests']);
        },
      });
  }
}
