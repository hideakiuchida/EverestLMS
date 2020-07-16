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

@NgModule({
   declarations: [
      RealizarCursosComponent,
      CursoCardComponent,
      CursoParticipanteComponent,
      LeccionParticipanteComponent
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
      CursoDetalleResolver
   ]
})
export class EscaladorModule { }
