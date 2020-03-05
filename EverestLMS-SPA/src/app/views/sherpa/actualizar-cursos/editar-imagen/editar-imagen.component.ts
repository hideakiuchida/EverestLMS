import { Component, OnInit, Input } from '@angular/core';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { Imagen } from 'src/app/models/imagen';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-editar-imagen',
  templateUrl: './editar-imagen.component.html',
  styleUrls: ['./editar-imagen.component.css']
})
export class EditarImagenComponent implements OnInit {
  imagen: Imagen;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  idEtapa: any;
  idCurso: any;

  constructor(private cursoService: CursosService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      const imagenes = data.imagenes;
      if  (imagenes != null && imagenes.length > 0) {
        this.imagen = imagenes[0];
      }
    });
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.initializeUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'etapas/' + this.idEtapa + '/cursos/' + this.idCurso + '/imagenes/',
      isHTML5: true,
      allowedFileType: ['image'],
      removeAfterUpload: true,
      autoUpload: false,
      maxFileSize: 10 * 1024 * 1024
    });

    this.uploader.onAfterAddingFile = (file) => {file.withCredentials = false; };

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        this.loadImagen(this.idEtapa, this.idCurso, response);
      }
    };
  }

  eliminarImagen(idImagen: number) {
    this.alertify.confirm('¿Está seguro de eliminar la imagen?', () => {
      this.cursoService.deleteImagen(this.idEtapa, this.idCurso, idImagen).subscribe(() => {
        this.alertify.success('La imagen se eliminó.');
        this.loadImagenes(this.idEtapa, this.idCurso);
      }, error => {
        this.alertify.error(error.error);
      });
    });
  }

  loadImagen(idEtapa, idCurso, idImagen) {
    this.cursoService.getImagen(idEtapa, idCurso, idImagen).subscribe((imagen: Imagen) => {
      this.imagen = imagen;
    }, error => {
      this.alertify.error(error.error);
    });
  }

  loadImagenes(idEtapa, idCurso) {
    this.cursoService.getImagenes(idEtapa, idCurso).subscribe((imagenes: Imagen[]) => {
      if  (imagenes != null && imagenes.length > 0) {
        this.imagen = imagenes[0];
      } else {
        this.imagen = null;
      }
    }, error => {
      this.alertify.error(error.error);
    });
  }

}
