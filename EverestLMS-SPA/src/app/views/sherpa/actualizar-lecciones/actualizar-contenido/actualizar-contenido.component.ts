import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
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

  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  leccionToUpdate: LeccionToRegister;

  constructor(private leccionService: LeccionService, private route: ActivatedRoute, private router: Router,
              private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.leccionToUpdate = data.leccion;
      // tslint:disable-next-line:no-debugger
      debugger;
      this.htmlText = data.leccion.contenidoHTML;
    });
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
  }

  submit() {
    // tslint:disable-next-line:no-debugger
    debugger;
    this.leccionToUpdate.contenidoHTML = this.htmlText;
    this.leccionService.editLeccion(this.idEtapa, this.idCurso, this.idLeccion, this.leccionToUpdate)
    .subscribe((updated: boolean) => {
      if (updated) {
        this.alertify.success('Se grabo el contenido existosamente.');
      }
    }, error => {
      this.alertify.error(error.message);
    }, () => {
      this.router.navigate(['actualizar-lecciones']);
    });
  }
}
