import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';

const routes: Routes = [
  { path: 'employees', component: EmployeesComponent },
  { path: '', redirectTo: '/employees',  pathMatch: 'full'},
  // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
