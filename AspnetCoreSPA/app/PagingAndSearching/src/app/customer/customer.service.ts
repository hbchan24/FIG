import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from "@angular/common/http";  
import { Observable } from "rxjs";  
import { Customer }  from "./customer"; 
import { CustomerModel }  from "./customermodel"; 

@Injectable({
  providedIn: 'root'
})

export class CustomerService {

  Url = 'http://localhost:5000/api/customer';  
  constructor(private http:HttpClient) { }    

  GetCustomer(pageNumber: number, itemsPerPage: number, searchString: string) :Observable<CustomerModel>  
  {
    return this.http.get<CustomerModel>(this.Url + "/get?pageNumber="+ pageNumber 
                                              + "&itemsPerPage=" + itemsPerPage
                                              + "&searchString=" + searchString);  
  }
}

