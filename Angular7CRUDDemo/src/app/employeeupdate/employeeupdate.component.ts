import { Component, OnInit, ViewChild, Input, EventEmitter, Output, ElementRef } from '@angular/core';
import { EmployeeDataService } from '../DataService/EmployeeDataService';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Employee } from 'src/Models/Employee';

@Component({
  selector: 'app-employeeupdate',
  templateUrl: './employeeupdate.component.html',
  styleUrls: ['./employeeupdate.component.css']
})
export class EmployeeupdateComponent implements OnInit {
  @Output() nameEvent = new EventEmitter<string>();
  @ViewChild('closeBtn') cb: ElementRef;
  @Input() reset:boolean = false;
  @ViewChild('regForm') myForm: NgForm;
  @Input() isReset: boolean = false;
  objtempemp: Employee;
  @Input() objemp: Employee = new Employee();
  constructor(private dataservice: EmployeeDataService, private router: Router) { }

  ngOnInit() {
  }

  EditEmployee(regForm: NgForm){
    this.dataservice.EditEmployee(this.objemp).subscribe(res => {
      alert('Employee updated successfully.');
      this.nameEvent.emit('ccc');
      this.cb.nativeElement.click();
    })
  }

}
