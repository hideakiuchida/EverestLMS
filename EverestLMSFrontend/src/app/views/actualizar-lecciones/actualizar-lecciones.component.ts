import { Component, OnInit } from '@angular/core';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Curso } from 'src/app/models/curso';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { Leccion } from 'src/app/models/leccion';

@Component({
  selector: 'app-actualizar-lecciones',
  templateUrl: './actualizar-lecciones.component.html',
  styleUrls: ['./actualizar-lecciones.component.css']
})
export class ActualizarLeccionesComponent implements OnInit {
  lecciones: Leccion[];
  cursos: Curso[];
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  search: any;
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  selectedEtapaId: any;
  selectedCursoId: any;
  dtOptions: DataTables.Settings = {};

  constructor(private leccionService: LeccionService, private cursoService: CursosService, private etapaService: EtapaService,
    private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.niveles = data['niveles'];
      this.lineaCarreras = data['lineaCarreras'];
    });
    this.initDatatable();
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
  }

  initDatatable() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true,
      paging: true,
      searching: false,
      info: false
    };
  }

  onKey(event: any) {
    this.search = event.target.value;
    this.loadLecciones(this.selectedEtapaId, this.selectedCursoId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  lineaCarreraSelected(value) {
    this.selectedLineaCarreraId = value;
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
  }

  nivelSelected(value) {
    this.selectedNivelId = value;
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);

  }

  etapaSelected(value) {
    this.selectedEtapaId = value;
    this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId);
  }

  cursoSelected(value) {
    this.selectedCursoId = value;
    this.loadLecciones(this.selectedEtapaId, this.selectedCursoId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  loadEtapas(idLineaCarrera, idNivel) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
       this.etapas = etapas;
       if (this.etapas != null && this.etapas.length > 0) {
        this.selectedEtapaId = this.etapas[0].id;
        this.selectedLineaCarreraId = this.etapas[0].idLineaCarrera;
        this.selectedNivelId = this.etapas[0].idNivel;
        this.loadCursos(this.selectedEtapaId , this.selectedLineaCarreraId, this.selectedNivelId);
       }
    }, error => {
      this.alertify.error(error);
    });
  }

  loadCursos(idEtapa, idLineaCarrera, idNivel) {
    this.cursoService.getCursos(idEtapa, idLineaCarrera, idNivel, null).subscribe((cursos: Curso[]) => {
      this.cursos = cursos;
      if (this.cursos != null && this.cursos.length > 0) {
        this.selectedCursoId = this.cursos[0].id;
        this.loadLecciones(this.selectedEtapaId, this.selectedCursoId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
       }
    }, error => {
      this.alertify.error(error);
    });
  }

  loadLecciones(idEtapa, idCurso, idLineaCarrera, idNivel, search) {
    this.leccionService.getLecciones(idEtapa, idCurso, idLineaCarrera, idNivel, search).subscribe((lecciones: Leccion[]) => {
      this.lecciones = lecciones;
    }, error => {
      this.alertify.error(error);
    });
  }

  eliminarLeccion(idEtapa, idCurso, idLeccion) {
    this.leccionService.deleteLeccion(idEtapa, idCurso, idLeccion).subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se elimino la lección');
        this.loadLecciones(this.selectedEtapaId, this.selectedCursoId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
      } else {
        this.alertify.warning('No se pudo eliminar la lección');
      }
    }, error => {
      this.alertify.error(error);
    });
  }
}
