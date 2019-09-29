import { Routes } from '@angular/router';
import { HomeComponent } from './views/home/home.component';
import { AsignarequiposComponent } from './views/asignar/asignarequipos/asignarequipos.component';
import { AsignarescaladorComponent } from './views/asignar/asignarescalador/asignarescalador.component';
import { EscaladoresResolver } from './resolvers/participante/escaladores.resolver';
import { SherpaResolver } from './resolvers/participante/sherpa.resolver';
import { CalendarioComponent } from './views/planificarcalendario/calendario/calendario.component';
import { EventoComponent } from './views/planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './views/planificarcalendario/criterioaceptacion/criterioaceptacion.component';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './views/planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { CursosComponent } from './views/actualizar-cursos/cursos.component';
import { FormularioCursoComponent } from './views/actualizar-cursos/formulario-curso/formulario-curso.component';
import { NivelResolver } from './resolvers/nivel/nivel.resolver';
import { LineaCarreraResolver } from './resolvers/lineacarrera/lineacarrera.resolver';
import { IdiomaResolver } from './resolvers/idiomas/idioma.resolver';
import { DificultadResolver } from './resolvers/dificultades/dificultad.resolver';
import { CursoResolver } from './resolvers/curso/curso.resolver';
import { EditarCursoComponent } from './views/actualizar-cursos/editar-curso/editar-curso.component';
import { EditarImagenComponent } from './views/actualizar-cursos/editar-imagen/editar-imagen.component';
import { CursoImagenResolver } from './resolvers/curso/curso-imagen.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'asignarequipos', component: AsignarequiposComponent},
    { path: 'calendario', component: CalendarioComponent},
    { path: 'cursos', component: CursosComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
    { path: 'formulario-curso', component: FormularioCursoComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver, idiomas: IdiomaResolver, dificultades: DificultadResolver}},
    { path: 'editar-imagen/:idEtapa/:idCurso', component: EditarImagenComponent, resolve: {imagenes: CursoImagenResolver}},
    { path: 'editar-curso/:idEtapa/:idCurso', component: EditarCursoComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver, idiomas: IdiomaResolver,
                  dificultades: DificultadResolver, curso: CursoResolver}},
    { path: 'asignarescalador/:idSherpa/:idLineaCarrera', component: AsignarescaladorComponent,
        resolve: {sherpa: SherpaResolver, escaladores: EscaladoresResolver}},
    { path: 'evento/:idCalendario', component: EventoComponent},
    { path: 'criterioaceptacion/:idCalendario', component: CriterioAceptacionComponent},
    { path: 'registrocriterioaceptacion/:idCalendario', component: RegistrocristerioaceptacionComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

