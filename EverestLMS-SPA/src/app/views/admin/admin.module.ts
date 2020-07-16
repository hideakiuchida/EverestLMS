import { NgModule } from '@angular/core';
import { CalendarModule, DateAdapter } from 'angular-calendar';
import { adapterFactory } from 'angular-calendar/date-adapters/date-fns';
import localeEs from '@angular/common/locales/es';
import { AsignarequiposComponent } from './asignar/asignarequipos.component';
import { SherpaDetalleComponent } from './asignar/sherpa-detalle/sherpa-detalle.component';
import { AsignarescaladorComponent } from './asignar/asignarescalador/asignarescalador.component';
import { EscaladorDetalleComponent } from './asignar/escalador-detalle/escalador-detalle.component';
import { CalendarioComponent } from './planificarcalendario/calendario/calendario.component';
import { EventoComponent } from './planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './planificarcalendario/criterioaceptacion/criterioaceptacion.component';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { ParticipanteService } from 'src/app/services/participante/participante.service';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { SherpaResolver } from 'src/app/resolvers/participante/sherpa.resolver';
import { EscaladoresResolver } from 'src/app/resolvers/participante/escaladores.resolver';
import { CriteriosAceptacionResolver } from 'src/app/resolvers/calendario/criteriosaceptacion.resolver';
import { registerLocaleData } from '@angular/common';
import { SharedModule } from '../shared/shared.module';

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
      SharedModule,
      CalendarModule.forRoot({
        provide: DateAdapter,
        useFactory: adapterFactory
      })
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
