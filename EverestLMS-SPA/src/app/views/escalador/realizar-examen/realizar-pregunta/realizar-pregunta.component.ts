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
    window.addEventListener('keyup', this.disableF5);
    window.addEventListener('keydown', this.disableF5);

    this.route.data.subscribe(data => {
      this.examen = data.examen;
      this.pregunta = data.pregunta;
      this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
      this.isExamenLeccion = this.examen.idLeccion != null;
      this.porcentajeProgreso = (this.pregunta.numeroOrden / this.examen.totalPreguntas) * 100;
    });
    this.startTimer();
  }

  disableF5(e) {
    if ((e.which || e.keyCode) === 116) {
        e.preventDefault();
    }
  }

  startTimer() {
    this.tiempoRestante = this.examen.tiempoRestante;
    this.interval = setInterval(() => {
      if (this.tiempoRestante <= 0) {
        this.alertify.message('El tiempo del examen ha terminado.');
        this.finalizar();
        clearInterval(this.interval);
      }
      if (this.tiempoRestante > 0) {
        this.tiempoRestante -= 1000;
      }
      const date = new Date();
      date.setTime(this.tiempoRestante);
      this.tiempoRestanteTime = date;
    }, 1000);
  }

  getRespuestaToUpdate(): RespuestaEscaladorToUpdate {
    this.respuesta = this.pregunta.respuestas.filter(x => x.id === this.idRespuestaSelected)[0];
    const respuestaEscaladorToUpdate: RespuestaEscaladorToUpdate = {
      idPregunta: +this.pregunta.idPregunta,
      descripcionPregunta: this.pregunta.descripcionPregunta,
      idRespuesta: +this.idRespuestaSelected ?? 1,
      descripcionRespuesta: this.respuesta.descripcion  ?? ''
    };
    return respuestaEscaladorToUpdate;
  }

  calcularVidasRestantes() {
    if (this.respuesta == null || !this.respuesta.esCorrecto) {
      this.examen.vidasRestante = this.examen.vidasRestante - 1;
    }
    if (this.examen.vidasRestante <= 0) {
      this.finalizar();
      clearInterval(this.interval);
    }
  }

  siguiente() {
    const respuestaEscaladorToUpdate = this.getRespuestaToUpdate();
    if (this.isExamenLeccion) {
      this.calcularVidasRestantes();
    }
    this.examenService.updateEscaladorRespuestas(this.examen.id, this.pregunta.idRespuestaEscalador, respuestaEscaladorToUpdate)
    .subscribe((updated: boolean) => {
      this.examen.numeroPreguntaActual = this.examen.numeroPreguntaActual + 1;
      if (updated) {
        this.actualizarExamen(false, this.examen.numeroPreguntaActual);
      } else {
        this.alertify.error('No se pudo actualizar el examen');
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  finalizar() {
    const respuestaEscaladorToUpdate = this.getRespuestaToUpdate();
    if (!(this.examen.vidasRestante <= 0) && this.isExamenLeccion) {
      this.calcularVidasRestantes();
    }
    this.examenService.updateEscaladorRespuestas(this.examen.id, this.pregunta.idRespuestaEscalador, respuestaEscaladorToUpdate)
    .subscribe((updated: boolean) => {
      if (updated) {
        this.actualizarExamen(true, this.examen.numeroPreguntaActual);
      } else {
        this.alertify.error('No se pudo actualizar el examen');
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  actualizarExamen(finalizar: boolean, numeroPregunta: number) {
    const examenToUpdate: ExamenToUpdate = {
      usuarioKey: this.idParticipante,
      idEtapa: + this.examen.idEtapa,
      idCurso: +this.examen.idCurso,
      idLeccion: +this.examen.idLeccion,
      vidasRestante: +this.examen.vidasRestante,
      tiempoRestante: +this.tiempoRestante,
      numeroPreguntaActual: numeroPregunta,
      finalizado: finalizar
    };
    this.examenService.updateExamen(this.examen.id, examenToUpdate)
    .subscribe((updated: boolean) => {
      if (!updated) {
        return this.alertify.error('No se pudo actualizar el examen');
      }
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
