import { Component, OnInit } from '@angular/core';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { Leccion } from 'src/app/models/leccion';
import { Curso } from 'src/app/models/curso';

@Component({
  selector: 'app-curso-participante',
  templateUrl: './curso-participante.component.html',
  styleUrls: ['./curso-participante.component.css']
})
export class CursoParticipanteComponent implements OnInit {
  curso: Curso;
  lecciones: Leccion[];

  constructor(private leccionParticipanteService: LeccionService,
    private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.curso = data['curso'];
      this.lecciones = data['lecciones'];
    });
  }

}
