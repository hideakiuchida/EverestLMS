import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { AsignarequiposComponent } from './views/asignar/asignarequipos/asignarequipos.component';
import { AsignarescaladorComponent } from './views/asignar/asignarescalador/asignarescalador.component';
import { EscaladoresResolver } from './resolvers/participante/escaladores.resolver';
import { SherpaResolver } from './resolvers/participante/sherpa.resolver';
import { CalendarioComponent } from './views/planificarcalendario/calendario/calendario.component';


export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'asignarequipos', component: AsignarequiposComponent},
    { path: 'calendario', component: CalendarioComponent},
    // tslint:disable-next-line:max-line-length
    { path: 'asignarescalador/:idSherpa/:idLineaCarrera', component: AsignarescaladorComponent, resolve: {sherpa: SherpaResolver, escaladores: EscaladoresResolver}},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

