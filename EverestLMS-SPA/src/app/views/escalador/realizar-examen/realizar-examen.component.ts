import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Curso } from 'src/app/models/curso';
import { Examen } from 'src/app/models/examen';
import { Leccion } from 'src/app/models/leccion';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-realizar-examen',
  templateUrl: './realizar-examen.component.html',
  styleUrls: ['./realizar-examen.component.css']
})
export class RealizarExamenComponent implements OnInit {
  idParticipante: any;
  idCurso: any;
  idLeccion: any;
  isExamenLeccion: boolean;
  examen: Examen;
  leccion: Leccion;
  curso: Curso;
  nombreExamen: any;
  tiempoRestanteTime: any;

  constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
     this.examen = data.examen;
     this.curso = data.curso;
     this.leccion = data.leccion;
    });
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.isExamenLeccion = this.idLeccion != null;
    this.nombreExamen = this.isExamenLeccion ? this.leccion.nombre : this.curso.nombre;
    const date = new Date();
    date.setTime(this.examen.tiempoRestante);
    this.tiempoRestanteTime = date.getMinutes() + ':00';
  }
}
