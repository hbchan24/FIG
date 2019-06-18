import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule, HttpClient} from '@angular/common/http';   
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';   
import { DisplayCustomerComponent } from './customer/display-customer/display-customer.component';
import {NgxPaginationModule} from 'ngx-pagination';  
import { Ng2SearchPipeModule } from 'ng2-search-filter';   

@NgModule({
  declarations: [
    AppComponent,
    DisplayCustomerComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,FormsModule,  
    HttpClientModule,NgxPaginationModule,Ng2SearchPipeModule  
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }


