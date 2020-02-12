import { Component, OnInit } from '@angular/core';
import { SherpaLite } from 'src/app/models/sherpaLite';
import { ParticipanteService } from 'src/app/services/participante/participante.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Nivel } from 'src/app/models/nivel';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { NivelService } from 'src/app/services/nivel/nivel.service';
import { LineaCarreraService } from 'src/app/services/lineacarrera/lineacarrera.service';
import { Sherpa } from 'src/app/models/sherpa';
import { AsignacionService } from 'src/app/services/asignacion/asignacion.service';
import { Mensaje } from 'src/app/models/mensaje';
import { NgxSpinnerService } from 'ngx-spinner';
import { Sede } from 'src/app/models/sede';
import { SedeService } from 'src/app/services/sede/sede.service';

@Component({
  selector: 'app-asignarequipos',
  templateUrl: './asignarequipos.component.html',
  styleUrls: ['./asignarequipos.component.css']
})
export class AsignarequiposComponent implements OnInit {
  sherpas: SherpaLite[];
  selectedSherpa: SherpaLite;
  niveles: Nivel[];
  lineaCarreras: LineaCarrera[];
  sedes: Sede[];
  search: any;
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  selectedSedeId: any;
  sherpa: Sherpa;

  constructor(private participanteService: ParticipanteService,
      private lineaCarreraService: LineaCarreraService, private sedeService: SedeService,
      private asignacionService: AsignacionService,
      private alertify: AlertifyService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.loadLineaCarreras();
    this.loadSedes();
    this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
  }

  onKey(event: any) {
      this.search = event.target.value;
      this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
  }

  lineaCarreraSelected(value) {
    this.selectedLineaCarreraId = value;
    this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
  }

  sedeSelected(value) {
    this.selectedSedeId = value;
    this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
  }

  onSelect(sherpaLite: SherpaLite): void {
    this.selectedSherpa = sherpaLite;
    this.loadSherpa(this.selectedSherpa.id);
  }

  loadSherpas(idNivel, idLineaCarrera, idSede, search) {
    this.participanteService.getSherpas(idNivel, idLineaCarrera, idSede, search).subscribe((sherpas: SherpaLite[]) => {
      this.sherpas = sherpas;
      if (sherpas != null && sherpas.length > 0) {
        this.selectedSherpa = sherpas[0];
        this.loadSherpa(this.selectedSherpa.id);
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  loadSedes() {
    this.sedeService.getSedes().subscribe((sedes: Sede[]) => {
      this.sedes = sedes;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadLineaCarreras() {
    this.lineaCarreraService.getLineaCarreras().subscribe((lineaCarreras: LineaCarrera[]) => {
       this.lineaCarreras = lineaCarreras;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadSherpa(id) {
    this.participanteService.getSherpa(id).subscribe((sherpa: Sherpa) => {
      if (sherpa.conocimientos.length > 0) {
        sherpa.conocimientosString = '';
        for (let i = 0; i < sherpa.conocimientos.length; i++) {
          if ((sherpa.conocimientos.length === 1) || (i === (sherpa.conocimientos.length - 1))) {
            sherpa.conocimientosString += sherpa.conocimientos[i].descripcion;
          } else {
           sherpa.conocimientosString += sherpa.conocimientos[i].descripcion + ', ';
          }
        }
      }
      this.sherpa = sherpa;
    }, error => {
      this.alertify.error(error);
    });
  }

  desasignarEmitter(isDesasignado: boolean) {
    if (isDesasignado) {
      this.loadSherpa(this.sherpa.id);
    }
  }

  generar() {
    this.spinner.show();
    this.asignacionService.asignarAutomaticamente().subscribe((mensaje: Mensaje) =>  {
      this.spinner.hide();
      this.alertify.success(mensaje.message);
      this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
    }, error => {
      this.spinner.hide();
      this.alertify.error(error);
    });
  }

  generarDesasignacion() {
    this.asignacionService.desasignarAutomaticamente().subscribe((mensaje: Mensaje) =>  {
      this.alertify.success(mensaje.message);
      this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.selectedSedeId, this.search);
    }, error => {
      this.alertify.error(error);
    });
  }

}
