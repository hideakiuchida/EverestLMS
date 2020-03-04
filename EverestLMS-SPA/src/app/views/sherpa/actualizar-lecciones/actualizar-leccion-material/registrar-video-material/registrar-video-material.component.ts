import { Component, OnInit } from '@angular/core';
import { Video } from 'src/app/models/video';
import { FileUploader } from 'ng2-file-upload';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { LeccionService } from 'src/app/services/leccion/leccion.service';

@Component({
  selector: 'app-registrar-video-material',
  templateUrl: './registrar-video-material.component.html',
  styleUrls: ['./registrar-video-material.component.css']
})
export class RegistrarVideoMaterialComponent implements OnInit {
  video: Video;
  uploader: FileUploader;
  hasBaseDropZoneOver = false;
  baseUrl = environment.apiUrl;
  idEtapa: any;
  idCurso: any;
  idLeccion: any;
  titulo: string;

  constructor(private leccionService: LeccionService, private alertify: AlertifyService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.idEtapa = this.route.snapshot.paramMap.get('idEtapa');
    this.idCurso = this.route.snapshot.paramMap.get('idCurso');
    this.idLeccion = this.route.snapshot.paramMap.get('idLeccion');
    this.initializeUploader();
  }

  public fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  initializeUploader() {
    this.uploader = new FileUploader({
      url: this.baseUrl + 'etapas/' + this.idEtapa + '/cursos/' + this.idCurso + '/lecciones/'
      + this.idLeccion + '/lecciones-material/videos',
      isHTML5: true,
      allowedFileType: ['video'],
      removeAfterUpload: true,
      autoUpload: false
    });

    this.uploader.onSuccessItem = (item, response, status, headers) => {
      if (response) {
        this.loadVideo(this.idEtapa, this.idCurso, this.idLeccion, response);
      }
    };
  }

  loadVideo(idEtapa, idCurso, idLeccion, idVideo) {
    this.leccionService.getVideo(idEtapa, idCurso, idLeccion, idVideo).subscribe((video: Video) => {
      this.video = video;
    }, error => {
      this.alertify.error(error.error);
    });
  }
}
