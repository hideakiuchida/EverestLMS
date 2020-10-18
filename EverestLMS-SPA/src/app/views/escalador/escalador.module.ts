import { NgModule } from '@angular/core';
import { RealizarCursosComponent } from './realizar-cursos/realizar-cursos.component';
import { CursoCardComponent } from './realizar-cursos/curso-card/curso-card.component';
import { CursosPrediccionParticipanteResolver } from 'src/app/resolvers/curso-participante/cursos-prediccion-participante.resolver';
import { CursosParticipanteResolver } from 'src/app/resolvers/curso-participante/cursos-participante.resolver';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { EtapaParticipanteService } from 'src/app/services/etapa-participante/etapa-participante.service';
import { EtapasParticipanteResolver } from 'src/app/resolvers/etapa-participante/etapa-participante.resolver';
import { IdiomaResolver } from 'src/app/resolvers/idiomas/idioma.resolver';
import { SharedModule } from '../shared/shared.module';
import { CursoParticipanteComponent } from './realizar-cursos/curso-participante/curso-participante.component';
import { CursoDetalleResolver } from 'src/app/resolvers/curso-participante/curso-detalle.resolver';
import { LeccionParticipanteComponent } from './realizar-cursos/leccion-participante/leccion-participante.component';
import { LeccionParticipanteService } from 'src/app/services/leccion-participante/leccion-participante.service';
import { LeccionParticipanteResolver } from 'src/app/resolvers/leccion-participante/leccion.-participante.resolver';
import { RealizarExamenComponent } from './realizar-examen/realizar-examen.component';
import { GenerarExamenResolver } from 'src/app/resolvers/examen/generar-examen.resolver';
import { ExamenService } from 'src/app/services/examen/examen.service';
import { PreguntaExamenResolver } from 'src/app/resolvers/examen/pregunta-examen.resolver';
import { RealizarPreguntaComponent } from './realizar-examen/realizar-pregunta/realizar-pregunta.component';
import { ExamenResolver } from 'src/app/resolvers/examen/examen.resolver';

@NgModule({
   declarations: [
      RealizarCursosComponent,
      CursoCardComponent,
      CursoParticipanteComponent,
      LeccionParticipanteComponent,
      RealizarExamenComponent,
      RealizarPreguntaComponent
   ],
   imports: [
      SharedModule
   ],
   providers: [
      CursosPrediccionParticipanteResolver,
      CursosParticipanteResolver,
      CursoParticipanteService,
      EtapaService,
      EtapaParticipanteService,
      EtapasParticipanteResolver,
      IdiomaResolver,
      CursoDetalleResolver,
      LeccionParticipanteService,
      LeccionParticipanteResolver,
      ExamenService,
      GenerarExamenResolver,
      PreguntaExamenResolver,
      ExamenResolver
   ]
})
export class EscaladorModule { }
