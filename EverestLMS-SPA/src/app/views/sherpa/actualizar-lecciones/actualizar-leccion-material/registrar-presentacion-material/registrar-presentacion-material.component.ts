import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-registrar-presentacion-material',
  templateUrl: './registrar-presentacion-material.component.html',
  styleUrls: ['./registrar-presentacion-material.component.css']
})
export class RegistrarPresentacionMaterialComponent implements OnInit {
  leccionMaterialForm: FormGroup;
  leccionMaterialToRegiter: LeccionMaterial;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;

  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService,
     private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.createLeccionMaterialForm();
  }

  createLeccionMaterialForm() {
    this.leccionMaterialForm = this.formBuilder.group({
      titulo: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      contenidoTexto: ['', [Validators.required]]
    });
  }

  registrarLeccionMaterial() {
    if (this.leccionMaterialForm.valid) {
      this.leccionMaterialToRegiter = Object.assign({}, this.leccionMaterialForm.value);
      this.leccionMaterialToRegiter.idTipoContenido = 1;
      this.leccionService.createLeccionMaterial(this.idEtapa, this.idCurso, this.idLeccion, this.leccionMaterialToRegiter)
      .subscribe(() => {
        this.alertify.success('Se registró existosamente.');
      }, error => {
        this.alertify.error(error.message);
      }, () => {
        this.router.navigate(['actualizar-leccion-material', this.idEtapa, this.idCurso, this.idLeccion]);
      });
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
