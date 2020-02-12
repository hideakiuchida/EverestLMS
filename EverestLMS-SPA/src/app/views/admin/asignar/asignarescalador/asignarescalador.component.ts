import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ParticipanteService } from 'src/app/services/participante/participante.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { EscaladorLite } from 'src/app/models/escaladorLite';
import { Sherpa } from 'src/app/models/sherpa';
import { Nivel } from 'src/app/models/nivel';
import { AsignacionService } from 'src/app/services/asignacion/asignacion.service';
import { NivelService } from 'src/app/services/nivel/nivel.service';
import { Escalador } from 'src/app/models/escalador';

@Component({
  selector: 'app-asignarescalador',
  templateUrl: './asignarescalador.component.html',
  styleUrls: ['./asignarescalador.component.css']
})
export class AsignarescaladorComponent implements OnInit {
  escaladoresNoAsignados: EscaladorLite[];
  sherpa: Sherpa;
  selectedEscalador: EscaladorLite;
  niveles: Nivel[];
  search: any;
  escalador: Escalador;

  constructor(private participanteService: ParticipanteService, private asignacionService: AsignacionService,
      private nivelService: NivelService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.escaladoresNoAsignados = data['escaladores'];
      if (this.escaladoresNoAsignados.length === 0) {
        this.alertify.message('No existe escaladores sin asignar para el sherpa.');
      } else {
        this.selectedEscalador = this.escaladoresNoAsignados[0];
        this.loadEscalador(this.selectedEscalador.id);
      }
      this.sherpa = data['sherpa'];
    });
  }

  onKey(event: any) {
    this.search = event.target.value;
    this.loadEscaladoresNoAsignados(this.sherpa.idLineaCarrera, this.search);
  }

  onSelect(escaladorLite: EscaladorLite): void {
    this.selectedEscalador = escaladorLite;
    this.loadEscalador(this.selectedEscalador.id);
  }

  loadEscaladoresNoAsignados(idLineaCarrera, search) {
    this.asignacionService.getEscaladoresNoAsignados(idLineaCarrera, search).subscribe((escaladores: EscaladorLite[]) => {
      this.escaladoresNoAsignados = escaladores;
      if (this.escaladoresNoAsignados.length > 0) {
        this.selectedEscalador = escaladores[0];
        this.loadEscalador(this.selectedEscalador.id);
      } else {
        this.alertify.message('No existe escaladores sin asignar para el sherpa.');
      }
    }, error => {
      this.alertify.error(error);
    });
  }

  loadEscalador(id) {
    this.participanteService.getEscalador(id).subscribe((escalador: Escalador) => {
      this.escalador = escalador;
    }, error => {
      this.alertify.error(error);
    });
  }

}
