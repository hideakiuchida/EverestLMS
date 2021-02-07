import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { Pregunta } from 'src/app/models/pregunta';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-actualizar-contenido',
  templateUrl: './actualizar-contenido.component.html',
  styleUrls: ['./actualizar-contenido.component.css']
})
export class ActualizarContenidoComponent implements OnInit {
  baseUrl = environment.apiUrl;
  htmlText: any;
  dtOptions: DataTables.Settings = {};
  preguntas: Pregunta[];
  existPreguntas: boolean;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  leccionToUpdate: LeccionToRegister;

  constructor(private leccionService: LeccionService, private route: ActivatedRoute, private router: Router,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.leccionToUpdate = data.leccion;
      this.preguntas = data.preguntas;
      // tslint:disable-next-line:no-debugger
      debugger;
      this.htmlText = data.leccion.contenidoHTML;
      this.existPreguntas = this.preguntas.length > 0;
    });
    this.initParameters();
    this.initDatatable();
  }

  initParameters() {
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
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
  agregarPreguntas() {
    this.existPreguntas = true;
  }

  submit() {
    // tslint:disable-next-line:no-debugger
    debugger;
    this.leccionToUpdate.contenidoHTML = this.htmlText;
    this.leccionService.editLeccion(this.idEtapa, this.idCurso, this.idLeccion, this.leccionToUpdate)
    .subscribe((updated: boolean) => {
      if (updated) {
        this.alertify.success('Se grabo el contenido exitosamente.');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }

  registrarPreguntas() {
    this.router.navigate(['actualizar-preguntas', this.idEtapa, this.idCurso, this.idLeccion, '']);
  }

  editarPregunta(id) {
    this.router.navigate(['actualizar-preguntas', this.idEtapa, this.idCurso, this.idLeccion, id]);
  }


  eliminarPregunta(id) {
    this.leccionService.deletePregunta(this.idEtapa, this.idCurso, this.idLeccion, id)
    .subscribe((deleted: boolean) => {
      if (deleted) {
        this.alertify.success('Se eliminó existosamente.');
      }
    }, error => {
      this.alertify.error(error.message);
    });
  }
}
