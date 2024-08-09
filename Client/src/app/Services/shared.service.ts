import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  constructor() {}

  private studentSource = new BehaviorSubject<any>(null);
  editStudent$ = this.studentSource.asObservable();

  private detailsModeSubject = new BehaviorSubject<any>(null);
  isDetailsMode$ = this.detailsModeSubject.asObservable();

  setStudent(student: any) {
    this.studentSource.next(student);
  }

  setEditStudent(value: boolean) {
    this.detailsModeSubject.next(value);
  }
}
