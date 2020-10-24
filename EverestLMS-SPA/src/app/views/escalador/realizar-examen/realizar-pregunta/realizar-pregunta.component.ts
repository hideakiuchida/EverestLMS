import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Examen } from 'src/app/models/examen';
import { ExamenToUpdate } from 'src/app/models/examenToUpdate';
import { PreguntaExamen } from 'src/app/models/preguntaExamen';
import { Respuesta } from 'src/app/models/respuesta';
import { RespuestaEscaladorToUpdate } from 'src/app/models/respuestaEscaladorToUpdate';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ExamenService } from 'src/app/services/examen/examen.service';

@Component({
  selector: 'app-realizar-pregunta',
  templateUrl: './realizar-pregunta.component.html',
  styleUrls: ['./realizar-pregunta.component.css']
})
export class RealizarPreguntaComponent implements OnInit {
  idParticipante: any;
  isExamenLeccion: boolean;
  examen: Examen;
  pregunta: PreguntaExamen;
  tiempoRestante: any;
  tiempoRestanteTime: any;
  porcentajeProgreso: any;
  idRespuestaSelected: any;
  interval: any;
  respuesta: Respuesta;

  constructor(private examenService: ExamenService, private router: Router,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.examen = data.examen;
      this.pregunta = data.pregunta;
      this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
      this.isExamenLeccion = this.examen.idLeccion != null;
      this.porcentajeProgreso = (this.pregunta.numeroOrden / this.examen.totalPreguntas) * 100;
      this.startTimer();
    });
  }

  startTimer() {
    this.tiempoRestante = this.examen.tiempoRestante;
    this.interval = setInterval(() => {
      if (this.tiempoRestante > 0) {
        this.tiempoRestante -= 1000;
      }
      const date = new Date();
      date.setTime(this.tiempoRestante);
      this.tiempoRestanteTime = date.getMinutes() + ':' + date.getSeconds();
    }, 1000);
  }

  pauseTimer() {
    clearInterval(this.interval);
  }

  getRespuestaToUpdate(): RespuestaEscaladorToUpdate {
    this.respuesta = this.pregunta.respuestas.filter(x => x.id === this.idRespuestaSelected)[0];
    const respuestaEscaladorToUpdate: RespuestaEscaladorToUpdate = {
      idPregunta: +this.pregunta.idPregunta,
      descripcionPregunta: this.pregunta.descripcionPregunta,
      idRespuesta: +this.idRespuestaSelected,
      descripcionRespuesta: this.respuesta.descripcion
    };
    return respuestaEscaladorToUpdate;
  }

  siguiente() {
    const respuestaEscaladorToUpdate = this.getRespuestaToUpdate();
    this.examenService.updateEscaladorRespuestas(this.examen.id, this.pregunta.idRespuestaEscalador, respuestaEscaladorToUpdate)
    .subscribe((updated: boolean) => {
      this.examen.numeroPreguntaActual = this.examen.numeroPreguntaActual + 1;
      this.actualizarExamen(false, this.examen.numeroPreguntaActual);
    }, error => {
      this.alertify.error(error);
    });
  }

  finalizar() {
    const respuestaEscaladorToUpdate = this.getRespuestaToUpdate();
    this.examenService.updateEscaladorRespuestas(this.examen.id, this.pregunta.idRespuestaEscalador, respuestaEscaladorToUpdate)
    .subscribe((updated: boolean) => {
      this.actualizarExamen(true, this.examen.numeroPreguntaActual);
    }, error => {
      this.alertify.error(error);
    });
  }

  actualizarExamen(finalizar: boolean, numeroPregunta: number) {
    if (!this.respuesta.esCorrecto) {
      this.examen.vidasRestante--;
    }
    const examenToUpdate: ExamenToUpdate = {
      usuarioKey: this.idParticipante,
      idCurso: +this.examen.idCurso,
      idLeccion: +this.examen.idLeccion,
      vidasRestante: +this.examen.vidasRestante,
      tiempoRestante: +this.tiempoRestante,
      numeroPreguntaActual: numeroPregunta,
      finalizado: finalizar
    };
    // tslint:disable-next-line:no-debugger
    debugger;
    this.examenService.updateExamen(this.examen.id, examenToUpdate)
    .subscribe((updated: boolean) => {
      // tslint:disable-next-line:no-debugger
      debugger;
      if (finalizar) {
        this.router.navigate(['resultado-examen', this.idParticipante, this.examen.id]);
      } else {
        this.router.navigate(['realizar-pregunta', this.idParticipante, this.examen.id, numeroPregunta]);
      }
    }, error => {
      this.alertify.error(error);
    });
  }
}
