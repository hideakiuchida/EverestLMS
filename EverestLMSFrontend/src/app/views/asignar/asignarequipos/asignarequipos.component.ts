import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
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
  search: any;
  selectedNivelId: any;
  selectedLineaCarreraId: any;
  sherpa: Sherpa;

  constructor(private participanteService: ParticipanteService, private nivelService: NivelService,
      private lineaCarreraService: LineaCarreraService, private asignacionService: AsignacionService,
      private alertify: AlertifyService, private spinner: NgxSpinnerService) { }

  ngOnInit() {
    this.loadNiveles();
    this.loadLineaCarreras();
    this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.search);
  }

  onKey(event: any) {
      this.search = event.target.value;
      this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.search);
  }

  lineaCarreraSelected(value) {
    this.selectedLineaCarreraId = value;
    this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.search);
  }

  onSelect(sherpaLite: SherpaLite): void {
    this.selectedSherpa = sherpaLite;
    this.loadSherpa(this.selectedSherpa.id);
  }

  loadSherpas(idNivel, idLineaCarrera, search) {
    this.participanteService.getSherpas(idNivel, idLineaCarrera, search).subscribe((sherpas: SherpaLite[]) => {
      this.sherpas = sherpas;
      this.selectedSherpa = sherpas[0];
      this.loadSherpa(this.selectedSherpa.id);
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

  loadLineaCarreras() {
    this.lineaCarreraService.getLineaCarreras().subscribe((lineaCarreras: LineaCarrera[]) => {
      this.lineaCarreras = lineaCarreras;
    }, error => {
      this.alertify.error(error);
    });
  }

  loadSherpa(id) {
    this.participanteService.getSherpa(id).subscribe((sherpa: Sherpa) => {
      this.sherpa = sherpa;
    }, error => {
      this.alertify.error(error);
    });
  }

  desasignarEmitter(isDesasignado: boolean) {
    // tslint:disable-next-line:no-debugger
    debugger;
    if (isDesasignado) {
      this.loadSherpa(this.sherpa.id);
    }
  }

  generar() {
    this.spinner.show();
    this.asignacionService.asignarAutomaticamente().subscribe((mensaje: Mensaje) =>  {
      this.spinner.hide();
      this.alertify.success(mensaje.message);
      this.loadSherpas(this.selectedNivelId, this.selectedLineaCarreraId, this.search);
    }, error => {
      this.spinner.hide();
      this.alertify.error(error);
    });
  }

}
