import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { AsignarequiposComponent } from './views/asignar/asignarequipos/asignarequipos.component';
import { AsignarescaladorComponent } from './views/asignar/asignarescalador/asignarescalador.component';
import { EscaladoresResolver } from './resolvers/participante/escaladores.resolver';
import { SherpaResolver } from './resolvers/participante/sherpa.resolver';
import { CalendarioComponent } from './views/planificarcalendario/calendario/calendario.component';
import { EventoComponent } from './views/planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './views/planificarcalendario/criterioaceptacion/criterioaceptacion.component';
import { CriteriosAceptacionResolver } from './resolvers/calendario/criteriosaceptacion.resolver';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './views/planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { CursosComponent } from './views/cursos/cursos.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'asignarequipos', component: AsignarequiposComponent},
    { path: 'calendario', component: CalendarioComponent},
    { path: 'cursos', component: CursosComponent},
    { path: 'asignarescalador/:idSherpa/:idLineaCarrera', component: AsignarescaladorComponent,
        resolve: {sherpa: SherpaResolver, escaladores: EscaladoresResolver}},
    { path: 'evento/:idCalendario', component: EventoComponent},
    { path: 'criterioaceptacion/:idCalendario', component: CriterioAceptacionComponent},
    { path: 'registrocriterioaceptacion/:idCalendario', component: RegistrocristerioaceptacionComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

