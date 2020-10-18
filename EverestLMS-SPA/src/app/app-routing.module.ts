import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './views/shared/home/home.component';
import { AsignarequiposComponent } from './views/admin/asignar/asignarequipos.component';
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
import { PreguntasResolver } from './resolvers/leccion/preguntas.resolver';
import { ActualizarPreguntasComponent } from './views/sherpa/actualizar-lecciones/actualizar-preguntas/actualizar-preguntas.component';
import { PreguntaResolver } from './resolvers/leccion/pregunta.resolver';
import { RespuestasResolver } from './resolvers/leccion/respuestas.resolver';
import { ActualizarRespuestasComponent } from './views/sherpa/actualizar-lecciones/actualizar-respuestas/actualizar-respuestas.component';
import { RespuestaResolver } from './resolvers/leccion/respuesta.resolver';
import { LeccionMaterialResolver } from './resolvers/leccion/leccion-material.resolver';
import { CursoParticipanteComponent } from './views/escalador/realizar-cursos/curso-participante/curso-participante.component';
import { CursoDetalleResolver } from './resolvers/curso-participante/curso-detalle.resolver';
import { LeccionParticipanteComponent } from './views/escalador/realizar-cursos/leccion-participante/leccion-participante.component';
import { LeccionParticipanteResolver } from './resolvers/leccion-participante/leccion.-participante.resolver';
import { RealizarExamenComponent } from './views/escalador/realizar-examen/realizar-examen.component';
import { GenerarExamenResolver } from './resolvers/examen/generar-examen.resolver';
import { PreguntaExamenResolver } from './resolvers/examen/pregunta-examen.resolver';
import { ExamenResolver } from './resolvers/examen/examen.resolver';
import { RealizarPreguntaComponent } from './views/escalador/realizar-examen/realizar-pregunta/realizar-pregunta.component';

const routes: Routes = [
    { path: '', component: HomeComponent },
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'inicio', component: InicioComponent },
            // Asignacion
            { path: 'asignarequipos', component: AsignarequiposComponent },
            {
                path: 'asignarescalador/:idSherpa/:idLineaCarrera', component: AsignarescaladorComponent,
                resolve: { sherpa: SherpaResolver, escaladores: EscaladoresResolver }
            },
            // Calendario
            { path: 'calendario', component: CalendarioComponent },
            { path: 'evento/:idCalendario', component: EventoComponent },
            { path: 'criterioaceptacion/:idCalendario', component: CriterioAceptacionComponent },
            { path: 'registrocriterioaceptacion/:idCalendario', component: RegistrocristerioaceptacionComponent },
            // Mantenimiento Lecciones
            {
                path: 'actualizar-lecciones', component: ActualizarLeccionesComponent,
                resolve: { niveles: NivelResolver, lineaCarreras: LineaCarreraResolver }
            },
            {
                path: 'registrar-leccion', component: RegistrarLeccionComponent,
                resolve: { niveles: NivelResolver, lineaCarreras: LineaCarreraResolver }
            },
            {
                path: 'editar-leccion/:idEtapa/:idCurso/:idLeccion', component: EditarLeccionComponent,
                resolve: { niveles: NivelResolver, lineaCarreras: LineaCarreraResolver, curso: CursoResolver, leccion: LeccionResolver }
            },
            {
                path: 'actualizar-leccion-material/:idEtapa/:idCurso/:idLeccion', component: ActualizarLeccionMaterialComponent,
                resolve: {
                    leccionesMaterial: LeccionMaterialesResolver,
                    tipoContenidos: TipoContenidoResolver,
                    preguntas: PreguntasResolver
                }
            },
            {
                path: 'registrar-leccion-material/:idEtapa/:idCurso/:idLeccion/:idLeccionMaterial',
                component: RegistrarLeccionMaterialComponent,
                resolve: {
                    leccionMaterial: LeccionMaterialResolver,
                    tipoContenidos: TipoContenidoResolver
                }
            },
            {
                path: 'registrar-video-material/:idEtapa/:idCurso/:idLeccion/:idLeccionMaterial',
                component: RegistrarVideoMaterialComponent,
                resolve: {
                    leccionMaterial: LeccionMaterialResolver,
                    tipoContenidos: TipoContenidoResolver
                }
            },
            {
                path: 'actualizar-presentacion-material/:idEtapa/:idCurso/:idLeccion/:idLeccionMaterial',
                component: RegistrarPresentacionMaterialComponent,
                resolve: {
                    leccionMaterial: LeccionMaterialResolver,
                    tipoContenidos: TipoContenidoResolver }
            },
            {
                path: 'actualizar-pregunta/:idEtapa/:idCurso/:idLeccion/:idPregunta',
                component: ActualizarPreguntasComponent,
                resolve: {
                    pregunta: PreguntaResolver,
                    respuestas: RespuestasResolver
                }
            },
            {
                path: 'actualizar-respuesta/:idEtapa/:idCurso/:idLeccion/:idPregunta/:idRespuesta',
                component: ActualizarRespuestasComponent,
                resolve: { respuesta: RespuestaResolver }
            },
            // Mantenimiento Cursos
            {
                path: 'cursos', component: CursosComponent,
                resolve: { niveles: NivelResolver, lineaCarreras: LineaCarreraResolver }
            },
            {
                path: 'registrar-curso',
                component: RegistrarCursoComponent,
                resolve: {
                    niveles: NivelResolver,
                    lineaCarreras: LineaCarreraResolver,
                    idiomas: IdiomaResolver,
                    dificultades: DificultadResolver
                }
            },
            {
                path: 'editar-imagen/:idEtapa/:idCurso',
                component: EditarImagenComponent,
                resolve: { imagenes: CursoImagenResolver }
            },
            {
                path: 'editar-curso/:idEtapa/:idCurso',
                component: EditarCursoComponent,
                resolve: {
                    niveles: NivelResolver,
                    lineaCarreras: LineaCarreraResolver,
                    idiomas: IdiomaResolver,
                    dificultades: DificultadResolver,
                    curso: CursoResolver
                }
            },
            // Realizar Curso
            {
                path: 'realizar-cursos/:idParticipante',
                component: RealizarCursosComponent,
                resolve: {
                    cursos: CursosParticipanteResolver,
                    cursosPrediccion: CursosPrediccionParticipanteResolver,
                    etapas: EtapasParticipanteResolver,
                    idiomas: IdiomaResolver
                }
            },
            {
                path: 'curso-participante/:idParticipante/:idEtapa/:idCurso',
                component: CursoParticipanteComponent,
                resolve: {
                    cursoDetalle: CursoDetalleResolver
                }
            },
            {
                path: 'leccion-participante/:idParticipante/:idEtapa/:idCurso/:idLeccion',
                component: LeccionParticipanteComponent,
                resolve: {
                    leccionEscalador: LeccionParticipanteResolver
                }
            },
            // Realizar Examen
            {
                path: 'realizar-examen/:idParticipante/:idEtapa/:idCurso/:idLeccion',
                component: RealizarExamenComponent,
                resolve: {
                    examen: GenerarExamenResolver,
                    leccion: LeccionResolver
                }
            },
            {
                path: 'realizar-examen/:idParticipante/:idEtapa/:idCurso',
                component: RealizarExamenComponent,
                resolve: {
                    examen: GenerarExamenResolver,
                    curso: CursoResolver
                }
            },
            {
                path: 'realizar-pregunta/:idParticipante/:idExamen',
                component: RealizarPreguntaComponent,
                resolve: {
                    examen: ExamenResolver,
                    pregunta: PreguntaExamenResolver
                }
            }
        ]
    },
    { path: '**', redirectTo: '', pathMatch: 'full' }
];
@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }

