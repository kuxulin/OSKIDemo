import { Guid } from 'guid-typescript';
import Answer from './answer';

export default class Question {
  id: Guid;
  text: string;
  answers: Answer[];
  isAnswered: boolean;
  currentAnswerId: Guid;

  constructor(question: Question) {
    this.id = question.id;
    this.text = question.text;
    this.answers = question.answers;
    this.isAnswered = question.isAnswered ?? false;
    this.currentAnswerId = question.currentAnswerId;
  }
}
