import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RespuestaToRegister } from 'src/app/models/respuestaToRegister';
import { Respuesta } from 'src/app/models/respuesta';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { Router, ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';

@Component({
  selector: 'app-actualizar-respuestas',
  templateUrl: './actualizar-respuestas.component.html',
  styleUrls: ['./actualizar-respuestas.component.css']
})
export class ActualizarRespuestasComponent implements OnInit {
  respuesta: Respuesta;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  idPregunta: any;
  idRespuesta: any;
  form: FormGroup;
  isEditForm: boolean;
  respuestaToRegister: RespuestaToRegister;
  
  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService, 
    private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.respuesta = data.respuesta;
    });
    this.initParameters();
    this.createForm();
  }

  initParameters() {
    this.idEtapa = this.route.snapshot.params.idEtapa;
    this.idCurso = this.route.snapshot.params.idCurso;
    this.idLeccion = this.route.snapshot.params.idLeccion;
    this.idPregunta = this.route.snapshot.params.idPregunta;
    this.idRespuesta = this.route.snapshot.params.idRespuesta;
    this.isEditForm = this.idRespuesta != undefined && this.idRespuesta != '';
  }

  createForm() {
    this.form = this.formBuilder.group({
      descripcion: [this.respuesta.descripcion, [Validators.required, Validators.minLength(4), Validators.maxLength(2000)]],
      esCorrecto: [this.respuesta.esCorrecto ?? false]
    });
  }

  actualizarRespuesta() {
    debugger;
    if (this.form.valid) {
      this.respuestaToRegister = Object.assign({}, this.form.value);
      if (!this.isEditForm) {
        this.leccionService.createRespuesta(this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta, this.respuestaToRegister)
        .subscribe((id: number) => {
          this.idRespuesta = id;
          this.isEditForm = !this.isEditForm;
          this.alertify.success('Se registró existosamente.');
          this.router.navigate(['actualizar-pregunta', this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta]);
        }, error => {
          debugger;
          if (error.status == 400)
              this.alertify.warning(error.error);
          else
              this.alertify.error(error.message);
        });
      } else {
        this.leccionService.editRespuesta(this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta, this.idRespuesta, this.respuestaToRegister)
        .subscribe(() => {
          this.alertify.success('Se actualizó existosamente.');
          this.router.navigate(['actualizar-pregunta', this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta]);
        }, error => {
          if (error.status == 400)
              this.alertify.warning(error.error);
          else
              this.alertify.error(error.message);
        });
      }
      
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }
}
