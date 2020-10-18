import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Examen } from 'src/app/models/examen';
import { PreguntaExamen } from 'src/app/models/preguntaExamen';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

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
  respuestaSelected: PreguntaExamen;
  interval: any;

  constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
     this.examen = data.examen;
     this.pregunta = data.pregunta;
    });
    // tslint:disable-next-line:no-debugger
    debugger;
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    this.isExamenLeccion = this.examen.idLeccion != null;
    this.porcentajeProgreso = this.pregunta.numeroOrden / this.examen.totalPreguntas;
    this.startTimer();
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

  next() {
  }
}
