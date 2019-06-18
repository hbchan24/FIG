import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../customer.service';
import { Observable } from "rxjs";  
import { Customer }  from "../customer"; 
import { CustomerModel } from '../customermodel';
@Component({
  selector: 'app-display-customer',
  templateUrl: './display-customer.component.html',
  styleUrls: ['./display-customer.component.css']
})
export class DisplayCustomerComponent implements OnInit {


  public customer: CustomerModel;
    //Pagination: initializing p to one
    p: number = 1;
    total: number = 0;
    itemPerPage: number = 5;
    searchString: string = "";
  pageChanged($event): void {
    this.p = $event;
    this.employeeService.GetCustomer(this.p,this.itemPerPage,this.searchString).subscribe(
      response => {
        this.customer = response;
        this.total = response.total;
        
      }
    );
  }

  onSearchValueChange(searchStr) {
    
    this.employeeService.GetCustomer(this.p,this.itemPerPage,searchStr).subscribe(
      response => {
        this.customer = response;
        if(searchStr){
          this.total = response.data.count;
        }else{
          this.total = response.total;
        }
        
        this.searchString = searchStr;
      }
    );  
  }

  constructor(public employeeService:CustomerService) { }  
    
  loadDisplay(){  
    this.employeeService.GetCustomer(this.p,this.itemPerPage,this.searchString).subscribe(
      response => {
        this.customer = response;
        this.total = response.total
      }
    );  
    
  }  
  ngOnInit() {  
    this.loadDisplay();   
  } 

}
