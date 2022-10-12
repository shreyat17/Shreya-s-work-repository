import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EmployeeService } from 'src/app/services/employee.service';
import { IEmployee } from './employee-model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit, OnDestroy{
  employees =[] as IEmployee[];
  subscription!:Subscription

  constructor(private http:EmployeeService) { }
  ngOnDestroy(): void {
    if(this.subscription)
      this.subscription.unsubscribe();

  }
  ngOnInit(): void {
    this.loadEmployees();
  }
  loadEmployees(){
    this.subscription=this.http.getData("Employee").subscribe({
      next:(data:any)=>{
        this.employees =data.data as IEmployee[];
        console.log(this.employees);
      },
      error:reason=>console.log(reason)
    });
  }

}
