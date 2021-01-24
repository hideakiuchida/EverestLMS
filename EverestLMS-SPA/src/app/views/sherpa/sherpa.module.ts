import { NgModule } from '@angular/core';

import { CursosComponent } from './actualizar-cursos/cursos.component';
import { RegistrarCursoComponent } from './actualizar-cursos/registrar-curso/registrar-curso.component';
import { EditarCursoComponent } from './actualizar-cursos/editar-curso/editar-curso.component';
import { EditarImagenComponent } from './actualizar-cursos/editar-imagen/editar-imagen.component';
import { ActualizarLeccionesComponent } from './actualizar-lecciones/actualizar-lecciones.component';
import { EditarLeccionComponent } from './actualizar-lecciones/editar-leccion/editar-leccion.component';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { CursoImagenResolver } from 'src/app/resolvers/curso/curso-imagen.resolver';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { LeccionResolver } from 'src/app/resolvers/leccion/leccion.resolver';
import { TipocontenidoService } from 'src/app/services/tipocontenido/tipocontenido.service';
import { SharedModule } from '../shared/shared.module';
import { DificultadResolver } from 'src/app/resolvers/dificultades/dificultad.resolver';
import { CursoResolver } from 'src/app/resolvers/curso/curso.resolver';
import { RespuestasResolver } from 'src/app/resolvers/leccion/respuestas.resolver';
import { PreguntasResolver } from 'src/app/resolvers/leccion/preguntas.resolver';
import { PreguntaResolver } from 'src/app/resolvers/leccion/pregunta.resolver';
import { ActualizarPreguntasComponent } from './actualizar-lecciones/actualizar-preguntas/actualizar-preguntas.component';
import { RespuestaResolver } from 'src/app/resolvers/leccion/respuesta.resolver';
import { ActualizarRespuestasComponent } from './actualizar-lecciones/actualizar-respuestas/actualizar-respuestas.component';
import { ActualizarContenidoComponent } from './actualizar-lecciones/actualizar-contenido/actualizar-contenido.component';

@NgModule({
   declarations: [
      CursosComponent,
      RegistrarCursoComponent,
      EditarCursoComponent,
      EditarImagenComponent,
      ActualizarLeccionesComponent,
      EditarLeccionComponent,
      ActualizarPreguntasComponent,
      ActualizarRespuestasComponent,
      ActualizarContenidoComponent
   ],
   imports: [
      SharedModule
   ],
   providers: [
      CursosService,
      CursoImagenResolver,
      LeccionService,
      LeccionResolver,
      TipocontenidoService,
      DificultadResolver,
      CursoResolver,
      PreguntasResolver,
      RespuestasResolver,
      PreguntaResolver,
      RespuestaResolver
   ]
})
export class SherpaModule { }
