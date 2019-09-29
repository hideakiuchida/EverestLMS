import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
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

import { AppComponent } from './app.component';
import { NavComponent } from './views/nav/nav.component';
import { AsignarequiposComponent } from './views/asignar/asignarequipos/asignarequipos.component';
import { ErrorInterceptorProvider } from './services/error.interceptor';
import { AlertifyService } from './services/alertify/alertify.service';
import { appRoutes } from './routes';
import { HomeComponent } from './views/home/home.component';
import { ParticipanteService } from './services/participante/participante.service';
import { LineaCarreraService } from './services/lineacarrera/lineacarrera.service';
import { NivelService } from './services/nivel/nivel.service';
import { SherpaDetalleComponent } from './views/asignar/sherpa-detalle/sherpa-detalle.component';
import { AsignarescaladorComponent } from './views/asignar/asignarescalador/asignarescalador.component';
import { SherpaResolver } from './resolvers/participante/sherpa.resolver';
import { EscaladoresResolver } from './resolvers/participante/escaladores.resolver';
import { EscaladorDetalleComponent } from './views/asignar/escalador-detalle/escalador-detalle.component';
import { SedeService } from './services/sede/sede.service';
import { CalendarioComponent } from './views/planificarcalendario/calendario/calendario.component';
import { registerLocaleData, DatePipe } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CalendarioService } from './services/calendario/calendario.service';
import { EventoComponent } from './views/planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './views/planificarcalendario/criterioaceptacion/criterioaceptacion.component';
import { CriteriosAceptacionResolver } from './resolvers/calendario/criteriosaceptacion.resolver';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './views/planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { NivelResolver } from './resolvers/nivel/nivel.resolver';
import { LineaCarreraResolver } from './resolvers/lineacarrera/lineacarrera.resolver';
import { CursosComponent } from './views/actualizar-cursos/cursos.component';
import { FormularioCursoComponent } from './views/actualizar-cursos/formulario-curso/formulario-curso.component';
import { CursosService } from './services/curso/cursos.service';
import { IdiomaResolver } from './resolvers/idiomas/idioma.resolver';
import { DificultadResolver } from './resolvers/dificultades/dificultad.resolver';
import { CursoResolver } from './resolvers/curso/curso.resolver';
import { EditarCursoComponent } from './views/actualizar-cursos/editar-curso/editar-curso.component';
import { EditarImagenComponent } from './views/actualizar-cursos/editar-imagen/editar-imagen.component';
import { CursoImagenResolver } from './resolvers/curso/curso-imagen.resolver';

registerLocaleData(localeEs);

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      AsignarequiposComponent,
      HomeComponent,
      SherpaDetalleComponent,
      AsignarescaladorComponent,
      EscaladorDetalleComponent,
      CalendarioComponent,
      EventoComponent,
      CriterioAceptacionComponent,
      RegistrocristerioaceptacionComponent,
      CursosComponent,
      FormularioCursoComponent,
      EditarCursoComponent,
      EditarImagenComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes),
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
      NgbModule
   ],
   providers: [
      ErrorInterceptorProvider,
      AlertifyService,
      ParticipanteService,
      LineaCarreraService,
      CalendarioService,
      NivelService,
      SedeService,
      SherpaResolver,
      EscaladoresResolver,
      NivelResolver,
      LineaCarreraResolver,
      IdiomaResolver,
      DificultadResolver,
      CursoResolver,
      CriteriosAceptacionResolver,
      DatePipe,
      CursosService,
      CursoImagenResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
