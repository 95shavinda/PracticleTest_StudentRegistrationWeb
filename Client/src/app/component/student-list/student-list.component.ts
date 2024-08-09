import { Component, Inject, OnInit, ViewChild, inject } from '@angular/core';
import { StudentService } from '../../Services/student.service';
import { Student } from '../../../Models/student';
import { CommonModule, NgClass } from '@angular/common';
import { Router, RouterLink } from '@angular/router';
import { StudentDetailsComponent } from './student-details/student-details.component';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatPaginator } from '@angular/material/paginator';
import { SharedService } from '../../Services/shared.service';
import { Events } from '../../../Models/events';

@Component({
  selector: 'app-student-list',
  standalone: true,
  imports: [
    CommonModule,
    RouterLink,
    StudentDetailsComponent,
    NgClass,
    MatSortModule,
    MatTableModule,
    MatFormFieldModule,
    MatSortModule,
    MatPaginator,
  ],
  templateUrl: './student-list.component.html',
  styleUrl: './student-list.component.css',
})
export class StudentListComponent implements OnInit {
  private readonly router = inject(Router);
  constructor(
    private studentService: StudentService,
    private sharedService: SharedService
  ) {}

  displayedColumns: string[] = [
    'firstName',
    'lastName',
    'mobile',
    'email',
    'nic',
    'imageUrl',
  ];
  dataSource: any = [];

  @ViewChild(MatSort) sort!: MatSort;
  @ViewChild(MatPaginator) paginator!: MatPaginator;

  students: Student[] = [];
  invisibleStudentDetails: boolean = true;

  student!: Student;
  selectedStudentId: number | null = null;

  detailsVisible: boolean = false;
  isAddStudent: boolean = false;

  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents() {
    this.studentService.loadStudents().subscribe((response) => {
      this.dataSource = new MatTableDataSource(response.result);
      this.dataSource.result = response;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    });
  }

  applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value
      .trim()
      .toLowerCase();
    this.dataSource.filter = filterValue;
  }

  viewDetails(id: any): void {
    if (this.selectedStudentId === id) {
      this.invisibleStudentDetails = true;
      this.selectedStudentId = null;
      this.detailsVisible = false;
    } else {
      this.studentService.getStudentById(id).subscribe((response) => {
        this.student = response.result;
        this.invisibleStudentDetails = false;
        this.selectedStudentId = id;
        this.detailsVisible = true;
      });
    }
  }

  viewStudentAddingPage(isAdd: any) {
    this.sharedService.setStudent(isAdd);
    this.router.navigate(['/register']);
  }

  refreshGrid(value: Events): void {
    if ((value = Events.Delete)) {
      this.detailsVisible = false;
    }
    this.loadStudents();
  }
}
