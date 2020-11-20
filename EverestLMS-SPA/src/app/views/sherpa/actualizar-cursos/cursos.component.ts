import { Component, OnInit } from '@angular/core';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Curso } from 'src/app/models/curso';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { EtapaService } from 'src/app/services/etapa/etapa.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-cursos',
  templateUrl: './cursos.component.html',
  styleUrls: ['./cursos.component.css']
})
export class CursosComponent implements OnInit {
  cursos: Curso[];
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  etapas: Etapa[];
  search: any;
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  selectedEtapaId: any;
  dtOptions: DataTables.Settings = {};
  isFirstLoad: boolean;

  constructor(private cursoService: CursosService, private etapaService: EtapaService,
              private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.isFirstLoad = true;
    this.route.data.subscribe(data => {
      this.niveles = data.niveles;
      this.lineaCarreras = data.lineaCarreras;
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
    this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  lineaCarreraSelected(value) {
    this.selectedLineaCarreraId = value;
    this.isFirstLoad = true;
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
    this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  nivelSelected(value) {
    this.selectedNivelId = value;
    this.isFirstLoad = true;
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
    this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  etapaSelected(value) {
    this.selectedEtapaId = value;
    this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
  }

  loadEtapas(idLineaCarrera, idNivel) {
    this.etapaService.getEtapas(idLineaCarrera, idNivel, null).subscribe((etapas: Etapa[]) => {
       this.etapas = etapas;
       if (this.etapas != null && this.etapas.length > 0 && this.isFirstLoad) {
        this.isFirstLoad = false;
        this.selectedEtapaId = this.etapas[0].id;
        this.selectedLineaCarreraId = this.etapas[0].idLineaCarrera;
        this.selectedNivelId = this.etapas[0].idNivel;
        this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
       }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  loadCursos(idEtapa, idLineaCarrera, idNivel, search) {
    this.cursoService.getCursos(idEtapa, idLineaCarrera, idNivel, search).subscribe((cursos: Curso[]) => {
      this.cursos = cursos;
    }, error => {
      this.alertify.error(error.message);
    });
  }

  eliminarCurso(idEtapa, idCurso) {
    this.cursoService.deleteCurso(idEtapa, idCurso).subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se elimino el curso');
        this.loadCursos(this.selectedEtapaId, this.selectedLineaCarreraId, this.selectedNivelId, this.search);
      } else {
        this.alertify.warning('No se pudo eliminar el curso');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }
}
