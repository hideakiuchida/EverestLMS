import { Component, OnInit, Input } from '@angular/core';
import { Escalador } from 'src/app/models/escalador';
import { AsignacionService } from 'src/app/services/asignacion/asignacion.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Sherpa } from 'src/app/models/sherpa';
import { Mensaje } from 'src/app/models/mensaje';
import { Router } from '@angular/router';

@Component({
  selector: 'app-escalador-detalle',
  templateUrl: './escalador-detalle.component.html',
  styleUrls: ['./escalador-detalle.component.css']
})
export class EscaladorDetalleComponent implements OnInit {
  @Input() escalador: Escalador;
  @Input() sherpa: Sherpa;

  constructor(private asignacionService: AsignacionService, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  asignarEscalador(sherpaId, escaladorId) {
    this.asignacionService.asignar(sherpaId, escaladorId).subscribe((mensaje: Mensaje) =>  {
      this.alertify.success(mensaje.message);
      this.router.navigate(['/asignarequipos']);
    }, error => {
      this.alertify.error(error.error);
    });
  }
}
