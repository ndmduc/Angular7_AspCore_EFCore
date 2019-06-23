import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeAddComponent } from '../employee-add/employee-add.component';
import { EmployeeDataService } from '../DataService/EmployeeDataService';
import { Employee } from 'src/Models/Employee';
import { Router } from '@angular/router';
import { EmployeeupdateComponent } from '../employeeupdate/employeeupdate.component';
import { getNsPrefix } from '../../../node_modules/@angular/compiler';

@Component({
  selector: 'app-employeelist',
  templateUrl: './employeelist.component.html',
  styleUrls: ['./employeelist.component.css']
})
export class EmployeelistComponent implements OnInit {
  @ViewChild('empadd', {static: false}) addcomponent: EmployeeAddComponent;
  @ViewChild('regForm', {static: false}) editcomponent: EmployeeupdateComponent;

  empList: Employee[];
  dataavailable: boolean = false;
  tempemp: Employee;

  constructor(private dataservice: EmployeeDataService, private router: Router) { }

  ngOnInit() {
    this.LoadData();
  }

  LoadData() {
    this.dataservice.getEmployee().subscribe((tempdate) => {
      this.empList = tempdate;
      console.log(this.empList);
      if (this.empList.length > 0){
        this.dataavailable = true;
      }else{
        this.dataavailable = false;
      }
    }, err => {
      console.log(err);
    })
  }

  deleteconfirmation(id: string){
    if(confirm('Are you sure you want to delete this?')){
      this.tempemp = new Employee();
      this.tempemp.id =id;
      this.dataservice.DeleteEmployee(this.tempemp).subscribe(res => {
        alert('Deleted successfully');
        this.LoadData();
      })
    }
  }

  loadAddNew(){
    this.addcomponent.objemp.email ='';
    this.addcomponent.objemp.firstname ='';
    this.addcomponent.objemp.lastname ='';
    this.addcomponent.objemp.id ='';
    this.addcomponent.objemp.gender =0;
  }

  loadNewForm(id: string, email: string, firstname: string, lastname: string, gender: number){
   console.log(gender);
    this.editcomponent.objemp.email =email;
    this.editcomponent.objemp.firstname =firstname;
    this.editcomponent.objemp.lastname =lastname;
    this.editcomponent.objemp.id =id;
    this.editcomponent.objemp.gender =gender;
  }

  RefreshData(){
    this.LoadData();
  }
}
