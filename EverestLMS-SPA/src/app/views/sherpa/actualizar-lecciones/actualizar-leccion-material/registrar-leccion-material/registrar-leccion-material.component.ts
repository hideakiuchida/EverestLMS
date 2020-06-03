import { Component, OnInit } from '@angular/core';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-registrar-leccion-material',
  templateUrl: './registrar-leccion-material.component.html',
  styleUrls: ['./registrar-leccion-material.component.css']
})
export class RegistrarLeccionMaterialComponent implements OnInit {
  leccionMaterialForm: FormGroup;
  leccionMaterialToRegiter: LeccionMaterial;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  idLeccionMaterial: any;
  isEditForm: boolean;

  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService,
     private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      debugger;
      this.leccionMaterialToRegiter = data.leccionMaterial;
    });
    debugger;
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.idLeccionMaterial = this.route.snapshot.params.idLeccionMaterial;
    this.isEditForm = this.idLeccionMaterial != undefined && this.idLeccionMaterial != '';
    this.createLeccionMaterialForm();
  }

  createLeccionMaterialForm() {
    this.leccionMaterialForm = this.formBuilder.group({
      titulo: [ this.leccionMaterialToRegiter.titulo, [Validators.required, Validators.minLength(4), Validators.maxLength(200)]],
      contenidoTexto: [this.leccionMaterialToRegiter.contenidoTexto, [Validators.required]]
    });
  }

  actualizarLeccionMaterial() {
    debugger;
    if (this.leccionMaterialForm.valid) {
      this.leccionMaterialToRegiter = Object.assign({}, this.leccionMaterialForm.value);
      this.leccionMaterialToRegiter.idTipoContenido = 1;
      if (this.isEditForm) {
        this.leccionService.editLeccionMaterial(this.idEtapa, this.idCurso, this.idLeccion, this.idLeccionMaterial, this.leccionMaterialToRegiter)
        .subscribe(() => {
          this.alertify.success('Se actualizó existosamente.');
        }, error => {
          this.alertify.error(error.message);
        }, () => {
          this.router.navigate(['actualizar-leccion-material', this.idEtapa, this.idCurso, this.idLeccion]);
        });
      } else {
        this.leccionService.createLeccionMaterial(this.idEtapa, this.idCurso, this.idLeccion, this.leccionMaterialToRegiter)
        .subscribe(() => {
          this.alertify.success('Se registró existosamente.');
        }, error => {
          this.alertify.error(error.message);
        }, () => {
          this.router.navigate(['actualizar-leccion-material', this.idEtapa, this.idCurso, this.idLeccion]);
        });
      }
      
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
