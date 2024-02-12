import { Guid } from 'guid-typescript';

export default class Answer {
  id: Guid;
  text: string;
  isRight: boolean;

  constructor(answer: Answer) {
    this.id = answer.id;
    this.text = answer.text;
    this.isRight = answer.isRight;
  }
}
