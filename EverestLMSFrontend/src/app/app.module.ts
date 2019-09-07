import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { DataTablesModule } from 'angular-datatables';
import {MatButtonModule, MatIconModule} from '@angular/material';
import { NgxSpinnerModule } from 'ngx-spinner';

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

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      AsignarequiposComponent,
      HomeComponent,
      SherpaDetalleComponent,
      AsignarescaladorComponent,
      EscaladorDetalleComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      RouterModule.forRoot(appRoutes),
      DataTablesModule,
      MatButtonModule,
      MatIconModule,
      NgxSpinnerModule
   ],
   providers: [
      ErrorInterceptorProvider,
      AlertifyService,
      ParticipanteService,
      LineaCarreraService,
      NivelService,
      SedeService,
      SherpaResolver,
      EscaladoresResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
