import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor() {}

  private studentSource = new BehaviorSubject<any>(null);
  editStudent$ = this.studentSource.asObservable();

  setStudent(student: any) {
    this.studentSource.next(student);
  }
}
