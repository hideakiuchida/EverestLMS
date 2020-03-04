import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Sherpa } from 'src/app/models/sherpa';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { SherpaLite } from 'src/app/models/sherpaLite';
import { AsignacionService } from 'src/app/services/asignacion/asignacion.service';
import { Mensaje } from 'src/app/models/mensaje';

@Component({
  selector: 'app-sherpa-detalle',
  templateUrl: './sherpa-detalle.component.html',
  styleUrls: ['./sherpa-detalle.component.css']
})
export class SherpaDetalleComponent implements OnInit {
  @Input() sherpa: Sherpa;
  @Output() desasignarEmitter = new EventEmitter();

  dtOptions: DataTables.Settings = {};

  constructor(private asignacionService: AsignacionService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 5,
      processing: true,
      paging: false,
      searching: false,
      info: false
    };
  }

  desasignarEscalador(sherpaId, escaladorId) {
    this.asignacionService.desasignar(sherpaId, escaladorId).subscribe((mensaje: Mensaje) =>  {
      this.alertify.success(mensaje.message);
      this.desasignarEmitter.emit(true);
    }, error => {
      this.alertify.error(error.error);
    });
  }
}
