import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Student } from '../../Models/student';
import { Observable } from 'rxjs';
import { Envelope } from '../../Models/envelope';

@Injectable({
  providedIn: 'root',
})
export class StudentService {
  private readonly baseUrl = 'https://localhost:7071/api';
  private readonly studentApiUrl = `${this.baseUrl}/students`;
  private readonly http = inject(HttpClient);

  loadStudents(): Observable<Envelope<Student[]>> {
    return this.http.get<Envelope<Student[]>>(`${this.studentApiUrl}`);
  }

  getStudentById(id: number): Observable<Envelope<Student>> {
    return this.http.get<Envelope<Student>>(`${this.studentApiUrl}/${id}`);
  }

  register(student: Student): Observable<Envelope<string>> {
    return this.http.post<Envelope<string>>(`${this.studentApiUrl}`, student);
  }

  deleteStudent(id: number): Observable<Envelope<string>> {
    return this.http.delete<Envelope<string>>(`${this.studentApiUrl}/${id}`);
  }

  updateStudent(id: number, studentData: any): Observable<Student> {
    return this.http.put<Student>(`${this.studentApiUrl}/${id}`, studentData);
  }
}
