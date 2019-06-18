import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {DisplayCustomerComponent} from './customer/display-customer/display-customer.component'

const routes: Routes = [  
  {
    path: '',
    component: DisplayCustomerComponent
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
