import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './views/shared/home/home.component';
import { AsignarequiposComponent } from './views/admin/asignar/asignarequipos/asignarequipos.component';
import { CalendarioComponent } from './views/admin/planificarcalendario/calendario/calendario.component';
import { ActualizarLeccionesComponent } from './views/sherpa/actualizar-lecciones/actualizar-lecciones.component';
import { NivelResolver } from './resolvers/nivel/nivel.resolver';
import { LineaCarreraResolver } from './resolvers/lineacarrera/lineacarrera.resolver';
import { RegistrarLeccionComponent } from './views/sherpa/actualizar-lecciones/registrar-leccion/registrar-leccion.component';
// tslint:disable-next-line:max-line-length
import { ActualizarLeccionMaterialComponent } from './views/sherpa/actualizar-lecciones/actualizar-leccion-material/actualizar-leccion-material.component';
import { LeccionMaterialesResolver } from './resolvers/leccion/leccion-materiales.resolver';
import { TipoContenidoResolver } from './resolvers/tipocontenido/tipocontenido.resolver';
// tslint:disable-next-line:max-line-length
import { RegistrarLeccionMaterialComponent } from './views/sherpa/actualizar-lecciones/actualizar-leccion-material/registrar-leccion-material/registrar-leccion-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarVideoMaterialComponent } from './views/sherpa/actualizar-lecciones/actualizar-leccion-material/registrar-video-material/registrar-video-material.component';
// tslint:disable-next-line:max-line-length
import { RegistrarPresentacionMaterialComponent } from './views/sherpa/actualizar-lecciones/actualizar-leccion-material/registrar-presentacion-material/registrar-presentacion-material.component';
import { CursosComponent } from './views/sherpa/actualizar-cursos/cursos.component';
import { RegistrarCursoComponent } from './views/sherpa/actualizar-cursos/registrar-curso/registrar-curso.component';
import { IdiomaResolver } from './resolvers/idiomas/idioma.resolver';
import { DificultadResolver } from './resolvers/dificultades/dificultad.resolver';
import { EditarImagenComponent } from './views/sherpa/actualizar-cursos/editar-imagen/editar-imagen.component';
import { CursoImagenResolver } from './resolvers/curso/curso-imagen.resolver';
import { EditarCursoComponent } from './views/sherpa/actualizar-cursos/editar-curso/editar-curso.component';
import { CursoResolver } from './resolvers/curso/curso.resolver';
import { AsignarescaladorComponent } from './views/admin/asignar/asignarescalador/asignarescalador.component';
import { EscaladoresResolver } from './resolvers/participante/escaladores.resolver';
import { SherpaResolver } from './resolvers/participante/sherpa.resolver';
import { EventoComponent } from './views/admin/planificarcalendario/evento/evento.component';
import { CriterioAceptacionComponent } from './views/admin/planificarcalendario/criterioaceptacion/criterioaceptacion.component';
// tslint:disable-next-line:max-line-length
import { RegistrocristerioaceptacionComponent } from './views/admin/planificarcalendario/registrocristerioaceptacion/registrocristerioaceptacion.component';
import { RealizarCursosComponent } from './views/escalador/realizar-cursos/realizar-cursos.component';
import { CursosPrediccionParticipanteResolver } from './resolvers/curso-participante/cursos-prediccion-participante.resolver';
import { CursosParticipanteResolver } from './resolvers/curso-participante/cursos-participante.resolver';
import { EtapasParticipanteResolver } from './resolvers/etapa-participante/etapa-participante.resolver';
import { LeccionResolver } from './resolvers/leccion/leccion.resolver';
import { EditarLeccionComponent } from './views/sherpa/actualizar-lecciones/editar-leccion/editar-leccion.component';
import { AuthGuard } from './guards/auth.guard';
import { InicioComponent } from './views/shared/inicio/inicio.component';

const routes: Routes = [
    { path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'inicio', component: InicioComponent},
            { path: 'asignarequipos', component: AsignarequiposComponent},
            { path: 'calendario', component: CalendarioComponent},
            { path: 'actualizar-lecciones', component: ActualizarLeccionesComponent,
                resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
            { path: 'registrar-leccion', component: RegistrarLeccionComponent,
                resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver}},
            { path: 'editar-leccion/:idEtapa/:idCurso/:idLeccion', component: EditarLeccionComponent,
                resolve: {niveles: NivelResolver, lineaCarreras: LineaCarreraResolver, curso: CursoResolver, leccion: LeccionResolver}},
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
            { path: 'registrar-curso', component: RegistrarCursoComponent,
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
                         etapas: EtapasParticipanteResolver, idiomas: IdiomaResolver}}
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full'}
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

