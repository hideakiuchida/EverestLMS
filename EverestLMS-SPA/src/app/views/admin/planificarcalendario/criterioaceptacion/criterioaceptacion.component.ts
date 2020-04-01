import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-criterioaceptacion',
  templateUrl: './criterioaceptacion.component.html',
  styleUrls: ['./criterioaceptacion.component.css']
})
export class CriterioAceptacionComponent implements OnInit {
  criteriosAceptacion: CriterioAceptacion[];
  idCalendario: any;
  dtOptions: DataTables.Settings = {};

  constructor(private calendarioService: CalendarioService,
              private alertifyService: AlertifyService,
              private route: ActivatedRoute,
              private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.initDataTable();
    this.idCalendario = this.route.snapshot.paramMap.get('idCalendario');
    this.loadCriteriosAceptacion(this.idCalendario);
  }

  initDataTable() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      processing: true,
      paging: false,
      searching: false,
      info: false
    };
  }

  loadCriteriosAceptacion(idCalendario) {
    this.spinner.show();
    this.calendarioService.getCriteriosAceptacion(idCalendario).subscribe((criteriosAceptacion: CriterioAceptacion[]) => {
      this.criteriosAceptacion = criteriosAceptacion;
    }, error => {
      this.alertifyService.error(error.error);
    }, () => {
      this.spinner.hide();
    });
  }

  eliminarCriterioAceptacion(idCalendario, id) {
    this.calendarioService.deleteCriterioAceptacion(idCalendario, id).subscribe((isDeleted: boolean) => {
      if (isDeleted) {
        this.alertifyService.success('Se elimnó el Criterio de Aceptación.');
        this.loadCriteriosAceptacion(idCalendario);
      } else {
        this.alertifyService.warning('No se puedo eliminar el Criterio de Aceptación.');
      }
    }, error => {
      this.alertifyService.error(error);
    });
  }
}
