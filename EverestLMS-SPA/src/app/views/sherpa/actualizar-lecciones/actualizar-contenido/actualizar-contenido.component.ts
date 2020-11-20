import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AngularEditorConfig } from '@kolkov/angular-editor';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-actualizar-contenido',
  templateUrl: './actualizar-contenido.component.html',
  styleUrls: ['./actualizar-contenido.component.css']
})
export class ActualizarContenidoComponent implements OnInit {
  htmlContent = '';
  baseUrl = environment.apiUrl;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;

  editorConfig: AngularEditorConfig;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.editorConfig = {
      editable: true,
        spellcheck: true,
        height: 'auto',
        minHeight: '0',
        maxHeight: 'auto',
        width: 'auto',
        minWidth: '0',
        translate: 'yes',
        enableToolbar: true,
        showToolbar: true,
        placeholder: 'Enter text here...',
        defaultParagraphSeparator: '',
        defaultFontName: '',
        defaultFontSize: '',
        fonts: [
          {class: 'arial', name: 'Arial'},
          {class: 'times-new-roman', name: 'Times New Roman'},
          {class: 'calibri', name: 'Calibri'},
          {class: 'comic-sans-ms', name: 'Comic Sans MS'}
        ],
        customClasses: [
        {
          name: 'quote',
          class: 'quote',
        },
        {
          name: 'redText',
          class: 'redText'
        },
        {
          name: 'titleText',
          class: 'titleText',
          tag: 'h1',
        },
      ],
      uploadUrl: this.baseUrl + 'etapas/' + this.idEtapa + '/cursos/' + this.idCurso + '/lecciones/' + this.idLeccion + '/imagenes',
      uploadWithCredentials: false,
      sanitize: true,
      toolbarPosition: 'top',
      toolbarHiddenButtons: [
        ['bold', 'italic'],
        ['fontSize']
      ]
    };
  }

}
