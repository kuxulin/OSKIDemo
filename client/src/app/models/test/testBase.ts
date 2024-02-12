import { Guid } from 'guid-typescript';

export default class TestBase {
  id: Guid = Guid.createEmpty();
  name: string = '';
}
