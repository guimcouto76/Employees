import { Injectable } from '@angular/core';
import { BaseService } from './base.service';
import { API_URL } from './constants';
import { Employee } from '../models/employee';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService {

  constructor(private httpClient: HttpClient) {
    super();
  }

  public getEmployees(startDate: string): Observable<Employee[]> {
    const url = `${API_URL}/employees/?startDate=${startDate}`;

    return this.httpClient.get<Employee[]>(url).pipe(
      catchError(this.handleError)
    );
  }

  public deleteEmployee(employeeId: number) {
    const url = `${API_URL}/employees/${employeeId}`;

    return this.httpClient.delete(url).pipe(
      catchError(this.handleError)
    );
  }
}
