import { NavComponent } from './nav/nav.component';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FileUploadModule } from 'ng2-file-upload';
import { FlatpickrModule } from 'angularx-flatpickr';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { TimepickerModule, BsDropdownModule } from 'ngx-bootstrap';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from 'src/app/app-routing.module';
import { CommonModule } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import { JwtModule } from '@auth0/angular-jwt';

export function tokenGetter() {
   return localStorage.getItem('token');
}


@NgModule({
   declarations: [
      NavComponent,
      RegisterComponent,
      HomeComponent
   ],
   imports: [
      CommonModule,
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      DataTablesModule,
      MatButtonModule,
      MatIconModule,
      NgxSpinnerModule,
      BrowserAnimationsModule,
      FileUploadModule,
      FlatpickrModule.forRoot(),
      BsDatepickerModule.forRoot(),
      BsDropdownModule.forRoot(),
      TimepickerModule.forRoot(),
      JwtModule.forRoot({
         config: {
             tokenGetter: tokenGetter,
             whitelistedDomains: ['localhost:64736'],
             blacklistedRoutes: ['localhost:64736/api/auth']
          }
       }),
      NgbModule,
      RouterModule,
      AppRoutingModule
   ],
   exports: [
      NavComponent,
      HomeComponent,
      CommonModule,
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      DataTablesModule,
      MatButtonModule,
      MatIconModule,
      NgxSpinnerModule,
      BrowserAnimationsModule,
      FileUploadModule,
      FlatpickrModule,
      BsDatepickerModule,
      TimepickerModule,
      NgbModule,
      AppRoutingModule
   ]
})
export class SharedModule { }
