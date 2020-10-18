import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Etapa } from 'src/app/models/etapa';
import { Idioma } from 'src/app/models/idioma';
import { Curso } from 'src/app/models/curso';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';

@Component({
  selector: 'app-realizar-cursos',
  templateUrl: './realizar-cursos.component.html',
  styleUrls: ['./realizar-cursos.component.css']
})
export class RealizarCursosComponent implements OnInit {
  etapas: Etapa[];
  idiomas: Idioma[];
  cursos: Curso[];
  cursosPrediccion: Curso[];
  selectedEtapaId: any;
  selectedIdiomaId: any;
  idParticipante: any;
  isEmptyCourses: boolean;

  constructor(private cursoParticipanteService: CursoParticipanteService,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.etapas = data.etapas;
      this.idiomas = data.idiomas;
      this.cursos = data.cursos;
      this.cursosPrediccion = data.cursosPrediccion;
      this.isEmptyCourses = this.cursos.length === 0;
    });
    this.idParticipante = this.route.snapshot.paramMap.get('idParticipante');
    console.log(this.idParticipante);
  }

  etapaSelected(value) {
    this.selectedEtapaId = value;
    this.loadCursosPorPartipante(this.selectedEtapaId, this.selectedIdiomaId);
  }

  idiomaSelected(value) {
    this.selectedIdiomaId = value;
    this.loadCursosPorPartipante(this.selectedEtapaId, this.selectedIdiomaId);
  }

  loadCursosPorPartipante(idEtapa, idIdioma) {
    this.cursoParticipanteService.getCursosPorParticipante(this.idParticipante, idEtapa, idIdioma).subscribe((cursos: Curso[]) => {
      this.cursos = cursos;
    }, error => {
      this.alertify.error(error.message);
    });
  }
}
