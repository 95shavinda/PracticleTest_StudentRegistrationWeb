import { Routes } from '@angular/router';
import { StudentRegistrationComponent } from './component/student-registration/student-registration.component';
import { StudentListComponent } from './component/student-list/student-list.component';
import { StudentDetailsComponent } from './component/student-list/student-details/student-details.component';

export const routes: Routes = [
  {
    path: '',
    component: StudentListComponent,
  },
  {
    path: 'students',
    component: StudentListComponent,
  },
  {
    path: 'register',
    component: StudentRegistrationComponent,
  },
];
