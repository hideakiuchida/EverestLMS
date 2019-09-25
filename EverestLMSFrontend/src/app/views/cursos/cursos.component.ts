import { Component, OnInit } from '@angular/core';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Curso } from 'src/app/models/curso';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Etapa } from 'src/app/models/etapa';
import { NivelService } from 'src/app/services/nivel/nivel.service';
import { LineaCarreraService } from 'src/app/services/lineacarrera/lineacarrera.service';
import { EtapaService } from 'src/app/services/etapa/etapa.service';

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

  constructor(private cursoService: CursosService, private nivelService: NivelService,
    private lineaCarreraService: LineaCarreraService, private etapaService: EtapaService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.isFirstLoad = true;
    this.initDatatable();
    this.loadLineaCarreras();
    this.loadNiveles();
    this.loadEtapas(this.selectedLineaCarreraId, this.selectedNivelId);
  }

  initDatatable() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true,
      paging: false,
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

  loadLineaCarreras() {
    this.lineaCarreraService.getLineaCarreras().subscribe((lineaCarreras: LineaCarrera[]) => {
       this.lineaCarreras = lineaCarreras;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadNiveles() {
    this.nivelService.getNiveles().subscribe((niveles: Nivel[]) => {
       this.niveles = niveles;
    }, error => {
      this.alertify.error(error);
    });
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
      this.alertify.error(error);
    });
  }

  loadCursos(idEtapa, idLineaCarrera, idNivel, search) {
    this.cursoService.getCursos(idEtapa, idLineaCarrera, idNivel, search).subscribe((cursos: Curso[]) => {
      this.cursos = cursos;
    }, error => {
      this.alertify.error(error);
    });
  }

  eliminarCurso(idEtapa, idCurso) {
    this.cursoService.deleteCurso(idEtapa, idCurso).subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se elimino el curso');
      } else {
        this.alertify.warning('No se pudo eliminar el curso');
      }
    }, error => {
      this.alertify.error(error);
    });
  }
}
