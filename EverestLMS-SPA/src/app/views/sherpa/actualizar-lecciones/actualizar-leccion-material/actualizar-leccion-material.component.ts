import { Component, OnInit } from '@angular/core';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { TipoContenido } from 'src/app/models/tipocontenido';
import { LeccionMaterialLite } from 'src/app/models/leccionMaterialLite';
import { Pregunta } from 'src/app/models/pregunta';

@Component({
  selector: 'app-actualizar-leccion-material',
  templateUrl: './actualizar-leccion-material.component.html',
  styleUrls: ['./actualizar-leccion-material.component.css']
})
export class ActualizarLeccionMaterialComponent implements OnInit {
  leccionesMaterial: LeccionMaterialLite[];
  tipoContenidos: TipoContenido[];
  preguntas: Pregunta[];
  selectedContenidoId: any;
  dtOptions: DataTables.Settings = {};
  idEtapa: any;
  idCurso: any;
  idLeccion: any;

  constructor(private leccionService: LeccionService, private route: ActivatedRoute,
    private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.leccionesMaterial = data['leccionesMaterial'];
      this.tipoContenidos = data['tipoContenidos'];
      this.preguntas = data['preguntas'];
    });
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.initDatatable();
  }

  initDatatable() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      processing: true,
      paging: true,
      searching: false,
      info: false,
      lengthChange: false
    };
  }

  loadLeccionesMaterial(idEtapa, idCurso, idLeccion) {
    this.leccionService.getLeccionMateriales(idEtapa, idCurso, idLeccion).subscribe((leccionesMaterial: LeccionMaterialLite[]) => {
        this.leccionesMaterial = leccionesMaterial;
    }, error => {
      this.alertify.error(error.message);
    });
  }

  loadPreguntas(idEtapa, idCurso, idLeccion) {
    this.leccionService.getPreguntas(idEtapa, idCurso, idLeccion).subscribe((preguntas: Pregunta[]) => {
        this.preguntas = preguntas;
    }, error => {
      this.alertify.error(error.message);
    });
  }

  registrarLeccionMaterial() {
    if (this.selectedContenidoId === '1') {
      this.router.navigate(['registrar-leccion-material', this.idEtapa, this.idCurso, this.idLeccion]);
    } else if (this.selectedContenidoId === '2') {
      this.router.navigate(['registrar-video-material', this.idEtapa, this.idCurso, this.idLeccion]);
    } else if (this.selectedContenidoId === '3') {
      this.router.navigate(['registrar-presentacion-material', this.idEtapa, this.idCurso, this.idLeccion]);
    } else {
      this.alertify.message('Tiene que seleccionar el Tipo de Contenido.');
    }
  }

  registrarPregunta() {
    this.router.navigate(['actualizar-pregunta', this.idEtapa, this.idCurso, this.idLeccion, '']);
  }

  eliminarLeccionMaterial(idLeccionMaterial) {
    this.leccionService.deleteLeccionMaterial(this.idEtapa, this.idCurso, this.idLeccion, idLeccionMaterial)
    .subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se elimino la lección material');
        this.loadLeccionesMaterial(this.idEtapa, this.idCurso, this.idLeccion);
      } else {
        this.alertify.warning('No se pudo eliminar la lección material');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  eliminarPregunta(idPregunta) {
    this.leccionService.deletePregunta(this.idEtapa, this.idCurso, this.idLeccion, idPregunta)
    .subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se elimino la pregunta');
        this.loadPreguntas(this.idEtapa, this.idCurso, this.idLeccion);
      } else {
        this.alertify.warning('No se pudo eliminar la pregunta');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }
}
