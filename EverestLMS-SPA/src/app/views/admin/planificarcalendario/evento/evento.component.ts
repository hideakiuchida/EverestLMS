import { Component, OnInit } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Evento } from 'src/app/models/evento';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsDatepickerConfig } from 'ngx-bootstrap';
import { EventoToRegister } from 'src/app/models/eventoToRegister';

@Component({
  selector: 'app-evento',
  templateUrl: './evento.component.html',
  styleUrls: ['./evento.component.css']
})
export class EventoComponent implements OnInit {
  idCalendario: any;
  eventoToRegister: EventoToRegister;
  eventoForm: FormGroup;
  bsConfig: Partial<BsDatepickerConfig>;

  constructor(private calendarioService: CalendarioService,
              private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private alertify: AlertifyService,
              private router: Router) { }

  ngOnInit() {
    this.idCalendario = this.route.snapshot.paramMap.get('idCalendario');
    this.bsConfig = {
      containerClass: 'theme-red'
    };
    this.createEventoForm();
  }

  createEventoForm() {
    this.eventoForm = this.formBuilder.group({
      titulo: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(100)]],
      descripcion: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(400)]],
      fechaInicio: [new Date(), Validators.required],
      horaInicio: [new Date(), Validators.required],
      fechaFinal: [new Date(), Validators.required],
      horaFinal: [new Date(), Validators.required],
      colorPrimario: ['#ff0000', Validators.required]
    });
  }

  registrarEvento() {
    if (this.eventoForm.valid) {
      this.eventoToRegister = Object.assign({}, this.eventoForm.value);
      const evento = this.mapEventoRegistertoEvento(this.eventoToRegister);
      if (evento.fechaFinal < evento.fechaInicio) {
        return this.alertify.warning('La fecha de inicio no puede ser mayor a la fecha final.');
      }
      this.calendarioService.createEvento(this.idCalendario, evento).subscribe(() => {
        this.alertify.success('Se registró exitosamente.');
      }, error => {
        this.alertify.error(error.message);
      }, () => {
        this.router.navigate(['calendario']);
      });
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }

  mapEventoRegistertoEvento(eventoToRegister: EventoToRegister) {
    const fi = eventoToRegister.fechaInicio;
    const hi = eventoToRegister.horaInicio;
    const ff = eventoToRegister.fechaFinal;
    const hf = eventoToRegister.horaFinal;
    const evento: Evento = {
      titulo: eventoToRegister.titulo,
      descripcion: eventoToRegister.descripcion,
      fechaInicio: new Date(fi.getFullYear(), fi.getMonth(), fi.getDate(), hi.getHours(), hi.getMinutes(), hi.getSeconds()),
      fechaFinal: new Date(ff.getFullYear(), ff.getMonth(), ff.getDate(), hf.getHours(), hf.getMinutes(), hf.getSeconds()),
      colorPrimario: eventoToRegister.colorPrimario
    };
    return evento;
  }
}
