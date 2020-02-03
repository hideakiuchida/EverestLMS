import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import {MatButtonModule, MatIconModule} from '@angular/material';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlatpickrModule } from 'angularx-flatpickr';
import localeEs from '@angular/common/locales/es';
import { BsDatepickerModule, TimepickerModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { registerLocaleData, DatePipe, CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavComponent } from './views/common/nav/nav.component';
import { HomeComponent } from './views/common/home/home.component';

import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify/alertify.service';
import { LineaCarreraService } from './services/lineacarrera/lineacarrera.service';
import { NivelService } from './services/nivel/nivel.service';
import { SedeService } from './services/sede/sede.service';
import { NivelResolver } from './resolvers/nivel/nivel.resolver';
import { LineaCarreraResolver } from './resolvers/lineacarrera/lineacarrera.resolver';

import { AppRoutingModule } from './app-routing.module';
import { AdminModule } from './views/admin/admin.module';
import { SherpaModule } from './views/sherpa/sherpa.module';
import { EscaladorModule } from './views/escalador/escalador.module';

registerLocaleData(localeEs);

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent
   ],
   imports: [
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
      TimepickerModule.forRoot(),
      NgbModule,
      AppRoutingModule,
      CommonModule, AdminModule, SherpaModule, EscaladorModule
   ],
   providers: [
      ErrorInterceptorProvider,
      AlertifyService,
      LineaCarreraService,
      NivelService,
      SedeService,
      NivelResolver,
      LineaCarreraResolver,
      DatePipe
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
