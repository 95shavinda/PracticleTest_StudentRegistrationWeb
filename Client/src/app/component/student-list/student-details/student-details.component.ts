import { Component, Input, OnInit, inject } from '@angular/core';
import { Student } from '../../../../Models/student';
import { CommonModule } from '@angular/common';
import { StudentService } from '../../../Services/student.service';
import { Router, RouterLink } from '@angular/router';
import { SharedService } from '../../../Services/shared.service';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-details',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule],
  templateUrl: './student-details.component.html',
  styleUrl: './student-details.component.css',
})
export class StudentDetailsComponent implements OnInit {
  @Input() studentDetails!: Student;

  private readonly router = inject(Router);

  constructor(
    private studentService: StudentService,
    private toastrService: ToastrService
  ) {}

  isEdit: boolean = false;

  ngOnInit(): void {}

  deleteStudent(id: any): void {
    this.studentService.deleteStudent(id).subscribe(() => {
      location.reload();
    });
  }

  onImageChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.studentDetails.imageURL = e.target.result;
      };
      reader.readAsDataURL(file);
    }
  }
  editStudent() {
    this.isEdit = true;
  }

  updateStudent(id: any) {
    this.isEdit = false;

    this.studentService.updateStudent(id, this.studentDetails).subscribe({
      next: (response) => {
        location.reload();
      },
      error: (err) => {
        console.error('An error occurred:', err);
      },
    });
  }
}
