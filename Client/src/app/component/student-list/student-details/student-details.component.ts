import {
  Component,
  Input,
  OnInit,
  Output,
  inject,
  EventEmitter,
} from '@angular/core';
import { Student } from '../../../../Models/student';
import { CommonModule } from '@angular/common';
import { StudentService } from '../../../Services/student.service';
import { Router, RouterLink } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { Events } from '../../../../Models/events';

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
  isDetailsMode: boolean = true;

  @Output() updateEvent = new EventEmitter<Events>();

  ngOnInit(): void {}

  deleteStudent(id: any): void {
    this.studentService.deleteStudent(id).subscribe({
      next: (res: any) => {
        this.updateEvent.emit(Events.Delete);
        this.toastrService.success(res.value, 'Success', {
          positionClass: 'toast-top-right',
        });
      },
      error: (err: any) => {
        this.toastrService.error(err.error.errors, 'Error', {
          positionClass: 'toast-top-right',
        });
      },
    });
  }

  onImageChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.studentDetails.imageUrl = e.target.result;
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
        this.updateEvent.emit(Events.Update);
        this.toastrService.success(response.value, 'Success', {
          positionClass: 'toast-top-right',
        });
      },
      error: (err) => {
        this.toastrService.error(err.error.errors, 'Error', {
          positionClass: 'toast-top-right',
        });
      },
    });
  }
}
