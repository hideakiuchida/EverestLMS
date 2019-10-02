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
import { ActualizarLeccionesComponent } from './views/actualizar-lecciones/actualizar-lecciones.component';
import { RegistrarLeccionComponent } from './views/actualizar-lecciones/registrar-leccion/registrar-leccion.component';
// tslint:disable-next-line:max-line-length
import { ActualizarLeccionMaterialComponent } from './views/actualizar-lecciones/actualizar-leccion-material/actualizar-leccion-material.component';
import { LeccionMaterialesResolver } from './resolvers/leccion/leccion-materiales.resolver';
import { TipoContenidoResolver } from './resolvers/tipocontenido/tipocontenido.resolver';
// tslint:disable-next-line:max-line-length
import { RegistrarLeccionMaterialComponent } from './views/actualizar-lecciones/actualizar-leccion-material/registrar-leccion-material/registrar-leccion-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarVideoMaterialComponent } from './views/actualizar-lecciones/actualizar-leccion-material/registrar-video-material/registrar-video-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarPresentacionMaterialComponent } from './views/actualizar-lecciones/actualizar-leccion-material/registrar-presentacion-material/registrar-presentacion-material.component';
import { RealizarCursosComponent } from './views/realizar-cursos/realizar-cursos.component';
import { CursosParticipanteResolver } from './resolvers/curso-participante/cursos-participante.resolver';
import { CursosPrediccionParticipanteResolver } from './resolvers/curso-participante/cursos-prediccion-participante.resolver';
import { EtapasParticipanteResolver } from './resolvers/etapa-participante/etapa-participante.resolver';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'asignarequipos', component: AsignarequiposComponent},
    { path: 'calendario', component: CalendarioComponent},
    { path: 'actualizar-lecciones', component: ActualizarLeccionesComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
    { path: 'registrar-leccion', component: RegistrarLeccionComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
    { path: 'editar-leccion', component: RegistrarLeccionComponent,
        resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
    { path: 'actualizar-leccion-material/:idEtapa/:idCurso/:idLeccion', component: ActualizarLeccionMaterialComponent,
        resolve: {leccionesMaterial: LeccionMaterialesResolver, tipoContenidos: TipoContenidoResolver}},
    { path: 'registrar-leccion-material/:idEtapa/:idCurso/:idLeccion', component: RegistrarLeccionMaterialComponent,
        resolve: {leccionesMaterial: LeccionMaterialesResolver, tipoContenidos: TipoContenidoResolver}},
    { path: 'registrar-video-material/:idEtapa/:idCurso/:idLeccion', component: RegistrarVideoMaterialComponent,
         resolve: {leccionesMaterial: LeccionMaterialesResolver, tipoContenidos: TipoContenidoResolver}},
    { path: 'actualizar-presentacion-material/:idEtapa/:idCurso/:idLeccion', component: RegistrarPresentacionMaterialComponent,
        resolve: {leccionesMaterial: LeccionMaterialesResolver, tipoContenidos: TipoContenidoResolver}},
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
    { path: 'realizar-cursos/:idParticipante', component: RealizarCursosComponent,
        resolve: {cursos: CursosParticipanteResolver, cursosPrediccion: CursosPrediccionParticipanteResolver,
                 etapas: EtapasParticipanteResolver, idiomas: IdiomaResolver}},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

