import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Curso } from 'src/app/models/curso';
import { Examen } from 'src/app/models/examen';
import { Leccion } from 'src/app/models/leccion';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { ParticipanteService } from 'src/app/services/participante/participante.service';

@Component({
  selector: 'app-resultado-examen',
  templateUrl: './resultado-examen.component.html',
  styleUrls: ['./resultado-examen.component.css']
})
export class ResultadoExamenComponent implements OnInit {
  idParticipante: any;
  isExamenLeccion: boolean;
  isAprobado: boolean;
  examen: Examen;
  curso: Curso;
  leccion: Leccion;
  puntaje: number;

  constructor(private cursoService: CursosService, private leccionService: LeccionService,
              private participanteService: ParticipanteService, private router: Router,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.examen = data.examen;
      this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    });
    this.isExamenLeccion = this.examen.idLeccion != null;
    if (this.isExamenLeccion) {
      this.isAprobado = this.examen.vidasRestante > 0;
      this.leccionService.getLeccion(this.examen.idEtapa, this.examen.idCurso, this.examen.idLeccion)
      .subscribe((leccion: Leccion) => {
        this.leccion =  leccion;
        this.puntaje = this.leccion.puntaje;
      }, error => {
        this.alertify.error(error);
      });
    } else {
      this.isAprobado = this.examen.nota > 85;
      this.cursoService.getCurso(this.examen.idEtapa, this.examen.idCurso)
      .subscribe((curso: Curso) => {
        this.curso =  curso;
        this.puntaje = this.curso.puntaje;
      }, error => {
        this.alertify.error(error);
      });
    }
  }

  finalizar() {
    // tslint:disable-next-line:no-debugger
    debugger;
    if (this.isAprobado) {
      this.participanteService.updatePuntaje(this.idParticipante, this.puntaje)
      .subscribe(() => {
        this.router.navigate(['realizar-cursos', this.idParticipante]);
      }, error => {
        this.alertify.error(error);
      });
    } else {
      this.router.navigate(['realizar-cursos', this.idParticipante]);
    }
  }

}
