import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-criterioaceptacion',
  templateUrl: './criterioaceptacion.component.html',
  styleUrls: ['./criterioaceptacion.component.css']
})
export class CriterioAceptacionComponent implements OnInit {
  @Output() eliminarEmitter = new EventEmitter();
  @Input() criteriosAceptacion: CriterioAceptacion[];
  dtOptions: DataTables.Settings = {};

  constructor(private calendarioService: CalendarioService,
    private alertifyService: AlertifyService) { }

  ngOnInit() {
    this.initDataTable();
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

  eliminarCriterioAceptacion(idCalendario, id) {
    this.calendarioService.deleteCriterioAceptacion(idCalendario, id).subscribe((isDeleted: boolean) => {
      if (isDeleted) {
        this.alertifyService.success('Se elimnó el Criterio de Aceptación.');
        this.eliminarEmitter.emit(true);
      } else {
        this.alertifyService.warning('No se puedo eliminar el Criterio de Aceptación.');
      }
    }, error => {
      this.alertifyService.error(error);
    });
  }
}
