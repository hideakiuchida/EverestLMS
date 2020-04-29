import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Respuesta } from 'src/app/models/respuesta';
import { PreguntaToRegister } from 'src/app/models/preguntaToRegister';
import { Pregunta } from 'src/app/models/pregunta';

@Component({
  selector: 'app-actualizar-preguntas',
  templateUrl: './actualizar-preguntas.component.html',
  styleUrls: ['./actualizar-preguntas.component.css']
})
export class ActualizarPreguntasComponent implements OnInit {
  respuestas: Respuesta[];
  pregunta: Pregunta;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  idPregunta: any;
  isEditForm: boolean;
  form: FormGroup;
  dtOptions: DataTables.Settings = {};
  preguntaToRegister: PreguntaToRegister;
  
  constructor(private formBuilder: FormBuilder, private leccionService: LeccionService, 
    private route: ActivatedRoute, private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.respuestas = data.respuestas;
      this.pregunta = data.pregunta;
    });
    this.initParameters();
    this.initDatatable();
    this.createForm();
  }

  initParameters() {
    this.idEtapa = this.route.snapshot.params.idEtapa;
    this.idCurso = this.route.snapshot.params.idCurso;
    this.idLeccion = this.route.snapshot.params.idLeccion;
    this.idPregunta = this.route.snapshot.params.idPregunta;
    this.isEditForm = this.idPregunta != undefined && this.idPregunta != '';
    debugger;
  }

  initDatatable() {
    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10,
      processing: true,
      paging: true,
      searching: false,
      info: false
    };
  }

  createForm() {
    this.form = this.formBuilder.group({
      descripcion: [this.pregunta.descripcion, [Validators.required, Validators.minLength(4), Validators.maxLength(200)]]
    });
  }

  actualizarPregunta() {
    debugger;
    if (this.form.valid) {
      this.preguntaToRegister = Object.assign({}, this.form.value);
      if (!this.isEditForm) {
        this.leccionService.createPregunta(this.idEtapa, this.idCurso, this.idLeccion, this.preguntaToRegister)
        .subscribe((id: number) => {
          this.idPregunta = id;
          this.isEditForm = !this.isEditForm;
          this.alertify.success('Se registró existosamente.');
        }, error => {
          this.alertify.error(error.message);
        });
      } else {
        this.leccionService.editPregunta(this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta, this.preguntaToRegister)
        .subscribe(() => {
          this.alertify.success('Se actualizó existosamente.');
        }, error => {
          this.alertify.error(error.message);
        });
      }
      
    } else {
      this.alertify.warning('Falta llenar campos.');
    }
  }

  registrarRespuestas() {
    this.router.navigate(['actualizar-respuestas', this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta]);
  }

  eliminarRespuesta(id) {
    this.leccionService.deleteRespuesta(this.idEtapa, this.idCurso, this.idLeccion, this.idPregunta, id)
    .subscribe((deleted: boolean) => {
      if (deleted)
      this.alertify.success('Se eliminó existosamente.');
    }, error => {
      this.alertify.error(error.message);
    })
  }

}
