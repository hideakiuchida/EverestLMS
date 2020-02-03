import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DataTablesModule } from 'angular-datatables';
import {MatButtonModule, MatIconModule} from '@angular/material';
import { NgxSpinnerModule } from 'ngx-spinner';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import { FlatpickrModule } from 'angularx-flatpickr';
import localeEs from '@angular/common/locales/es';
import { BsDatepickerModule, TimepickerModule } from 'ngx-bootstrap';
import { FileUploadModule } from 'ng2-file-upload';
import { AsignarequiposComponent } from './asignar/asignarequipos/asignarequipos.component';
import { SherpaDetalleComponent } from './asignar/sherpa-detalle/sherpa-detalle.component';
import { AsignarescaladorComponent } from './asignar/asignarescalador/asignarescalador.component';
import { EscaladorDetalleComponent } from './asignar/escalador-detalle/escalador-detalle.component';
import { CalendarioComponent } from './planificarcalendario/calendario/calendario.component';
import { EventoComponent } from './planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './planificarcalendario/criterioaceptacion/criterioaceptacion.component';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { ParticipanteService } from 'src/app/services/participante/participante.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { SherpaResolver } from 'src/app/resolvers/participante/sherpa.resolver';
import { EscaladoresResolver } from 'src/app/resolvers/participante/escaladores.resolver';
import { CriteriosAceptacionResolver } from 'src/app/resolvers/calendario/criteriosaceptacion.resolver';
import { registerLocaleData } from '@angular/common';
import { RouterModule } from '@angular/router';

registerLocaleData(localeEs);

@NgModule({
   declarations: [
      AsignarequiposComponent,
      SherpaDetalleComponent,
      AsignarescaladorComponent,
      EscaladorDetalleComponent,
      CalendarioComponent,
      EventoComponent,
      CriterioAceptacionComponent,
      RegistrocristerioaceptacionComponent
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
      CalendarModule.forRoot({
        provide: DateAdapter,
        useFactory: adapterFactory
      }),
      BsDatepickerModule.forRoot(),
      TimepickerModule.forRoot(),
      RouterModule,
      NgbModule
   ],
   providers: [
      ParticipanteService,
      CalendarioService,
      SherpaResolver,
      EscaladoresResolver,
      CriteriosAceptacionResolver,
   ]
})
export class AdminModule { }
