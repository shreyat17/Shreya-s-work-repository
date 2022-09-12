import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.css']
})
export class ServicesComponent implements OnInit {

  constructor() { }
  ngOnInit(): void {
    this.employees = [
      { empNumber: 1, empName: 'Shreya' },
      { empNumber: 2, empName: 'Manasa' },
      { empNumber: 3, empName: 'Navya' }
    ];
  }

  public service() { };
  public selectTab(val: number) {
    this.optionValue = val;
  }
}
