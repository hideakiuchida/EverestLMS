import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-leccion-participante',
  templateUrl: './leccion-participante.component.html',
  styleUrls: ['./leccion-participante.component.css']
})
export class LeccionParticipanteComponent implements OnInit {
  idParticipante: any;
  idCurso: any;
  idLeccion: any;

  constructor(private router: Router, private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
  }

}
