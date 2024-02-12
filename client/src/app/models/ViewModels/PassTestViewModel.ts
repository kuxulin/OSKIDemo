import { Guid } from 'guid-typescript';

export default class PassTestViewModel {
  testId: Guid = Guid.createEmpty();
  userId: Guid = Guid.createEmpty();
  answerIds: Guid[] = [];
}
