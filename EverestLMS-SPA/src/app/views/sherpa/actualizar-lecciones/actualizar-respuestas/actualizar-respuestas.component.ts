import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-actualizar-respuestas',
  templateUrl: './actualizar-respuestas.component.html',
  styleUrls: ['./actualizar-respuestas.component.css']
})
export class ActualizarRespuestasComponent implements OnInit {
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  idPregunta: any;
  form: FormGroup;
  
  constructor() { }

  ngOnInit() {
  }

  actualizarRespuesta() {}
}
