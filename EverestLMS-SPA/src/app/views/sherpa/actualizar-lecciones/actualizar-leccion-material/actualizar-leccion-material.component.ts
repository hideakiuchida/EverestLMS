import { Component, OnInit } from '@angular/core';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { TipoContenido } from 'src/app/models/tipocontenido';

@Component({
  selector: 'app-actualizar-leccion-material',
  templateUrl: './actualizar-leccion-material.component.html',
  styleUrls: ['./actualizar-leccion-material.component.css']
})
export class ActualizarLeccionMaterialComponent implements OnInit {
  leccionesMaterial: LeccionMaterial[];
  tipoContenidos: TipoContenido[];
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
    });
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.selectedContenidoId = this.tipoContenidos[0];
    this.initDatatable();
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

  loadLeccionesMaterial(idEtapa, idCurso, idLeccion) {
    this.leccionService.getLeccionMateriales(idEtapa, idCurso, idLeccion).subscribe((leccionesMaterial: LeccionMaterial[]) => {
      this.leccionesMaterial = leccionesMaterial;
    }, error => {
      this.alertify.error(error.error);
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
      this.alertify.error(error.error);
    });
  }
}
