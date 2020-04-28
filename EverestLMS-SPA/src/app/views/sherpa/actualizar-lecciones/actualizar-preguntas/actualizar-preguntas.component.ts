import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-actualizar-preguntas',
  templateUrl: './actualizar-preguntas.component.html',
  styleUrls: ['./actualizar-preguntas.component.css']
})
export class ActualizarPreguntasComponent implements OnInit {
  respuestas: any;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  form: FormGroup;
  dtOptions: DataTables.Settings = {};
  
  constructor() { }

  ngOnInit() {
    this.initDatatable();
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

  actualizarPregunta() {

  }

  registrarRespuestas() {

  }

  eliminarRespuesta(id) {

  }

}
