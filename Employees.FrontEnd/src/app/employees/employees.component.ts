import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { EmployeeService } from '../services/employee.service';
import { Subscription, Observable, config } from 'rxjs';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css']
})
export class EmployeesComponent implements OnInit, OnDestroy {
  employees: Observable<Employee[]>;
  deleteSubscripton: Subscription;


  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.getEmployees();
  }

  getEmployees() {
    this.employees = this.employeeService.getEmployeesCompleted5Years();
  }

  deleteEmployee(idEmployee: number) {
    if (confirm('Are you sure you want to delete this employee?')) {
      this.deleteSubscripton = this.employeeService.deleteEmployee(idEmployee).subscribe(data => {
        // Update Employee List
        this.getEmployees();
      });
    }
  }

  ngOnDestroy() {
    if (this.deleteSubscripton) {
      this.deleteSubscripton.unsubscribe();
    }
  }


}
