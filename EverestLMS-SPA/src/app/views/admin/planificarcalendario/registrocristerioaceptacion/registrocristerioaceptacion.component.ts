import { Component, OnInit } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-registrocristerioaceptacion',
  templateUrl: './registrocristerioaceptacion.component.html',
  styleUrls: ['./registrocristerioaceptacion.component.css']
})
export class RegistrocristerioaceptacionComponent implements OnInit {
  idCalendario: any;
  criterioAceptacionToRegister: CriterioAceptacion;
  criterioAceptacionForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private calendarioService: CalendarioService,
              private alertifyService: AlertifyService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.idCalendario = this.route.snapshot.paramMap.get('idCalendario');
    this.createCriterioAceptacionForm();
  }

  createCriterioAceptacionForm() {
    this.criterioAceptacionForm = this.formBuilder.group({
      descripcion: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(1000)]],
      medida: [''],
      valor: ['', [ Validators.pattern(/^\d+\.\d{2}$/), Validators.maxLength(10)]]
    });
  }

  registrarCriterioAceptacion() {
    if (this.criterioAceptacionForm.valid) {
      this.criterioAceptacionToRegister = Object.assign({}, this.criterioAceptacionForm.value);
      this.calendarioService.createCriterioAceptacion(this.idCalendario, this.criterioAceptacionToRegister).subscribe(() => {
        this.alertifyService.success('Se registró existosamente.');
      }, error => {
        this.alertifyService.error(error.error);
      }, () => {
        this.router.navigate(['calendario']);
      });
    } else {
      this.alertifyService.warning('Los datos no son validos.');
    }
  }

}
