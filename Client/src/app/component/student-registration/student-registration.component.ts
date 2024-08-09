import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { Student } from '../../../Models/student';
import { StudentService } from '../../Services/student.service';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule, DatePipe } from '@angular/common';
import { SharedService } from '../../Services/shared.service';
import { ToastrModule, ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-student-registration',
  standalone: true,
  imports: [
    RouterLink,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    ToastrModule,
  ],
  templateUrl: './student-registration.component.html',
  styleUrl: './student-registration.component.css',
})
export class StudentRegistrationComponent implements OnInit {
  student: Student = {
    firstName: '',
    lastName: '',
    phoneNumber: '',
    email: '',
    nic: '',
    dateOfBirth: new Date(),
    address: '',
    imageURL: '',
  };

  editStudent: any;
  errors: any = [];

  imageUrl: any;

  private readonly router = inject(Router);

  studentForm!: FormGroup;
  isFormSubmitted: boolean = false;

  isEdit: boolean = false;

  constructor(
    private studentService: StudentService,
    private sharedService: SharedService,
    private toastrService: ToastrService
  ) {
    this.studentForm = new FormGroup({
      firstName: new FormControl('', [Validators.required]),
      lastName: new FormControl(null, [Validators.required]),
      phoneNumber: new FormControl(null, [Validators.required]),
      email: new FormControl(null, [Validators.required, Validators.email]),
      nic: new FormControl(null, [Validators.required]),
      dateOfBirth: new FormControl(null, [Validators.required]),
      address: new FormControl(null, [Validators.required]),
    });
  }

  ngOnInit(): void {}

  loadStudentAddPage() {
    this.sharedService.editStudent$.subscribe((student) => {
      this.isEdit = false;
    });
  }

  loadDataToEdit() {
    debugger;
    this.sharedService.editStudent$.subscribe((student) => {
      this.isEdit = true;
      this.editStudent = student;
      this.student = this.editStudent;
    });
  }

  onSubmit(): void {
    const isFormValid = this.studentForm.valid;
    this.isFormSubmitted = true;
    const student = {
      firstName: this.student.firstName,
      lastName: this.student.lastName,
      phoneNumber: this.student.phoneNumber,
      email: this.student.email,
      nic: this.student.nic,
      dateOfBirth: this.student.dateOfBirth,
      address: this.student.address,
      imageURL: this.imageUrl,
    };

    this.studentService.register(student).subscribe({
      next: (res: any) => {
        this.router.navigate(['/students']);
        this.toastrService.success('Student Added Successfully', 'Success', {
          positionClass: 'toast-top-right',
        });
      },
      error: (err: any) => {
        this.errors = err.error.errors;
      },
    });
  }

  previewProfilePicture(event: any) {
    const reader = new FileReader();
    reader.onload = () => {
      const output = document.getElementById(
        'profile-image-preview'
      ) as HTMLImageElement;
      output.src = reader.result as string;
      this.imageUrl = output.src;
    };
    reader.readAsDataURL(event.target.files[0]);
  }
}
