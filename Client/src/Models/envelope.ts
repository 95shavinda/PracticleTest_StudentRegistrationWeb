export class Envelope<T> {
  result: T;
  errors: string[] | null;
  timeGenerated: Date;
  success: boolean;

  constructor(result: T, errors: string[] | null, success: boolean) {
    this.result = result;
    this.errors = errors;
    this.timeGenerated = new Date();
    this.success = success;
  }
}
