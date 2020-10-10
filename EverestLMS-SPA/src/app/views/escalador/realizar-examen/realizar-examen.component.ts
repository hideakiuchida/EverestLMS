import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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

  constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
     /* this.cursoDetalle = data.cursoDetalle;
      this.lecciones = this.cursoDetalle.lecciones; */
    });
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
  }
}
