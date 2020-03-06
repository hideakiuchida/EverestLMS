import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Leccion } from 'src/app/models/leccion';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';
import { Video } from 'src/app/models/video';
import { LeccionMaterialLite } from 'src/app/models/leccionMaterialLite';

@Injectable({
  providedIn: 'root'
})
export class LeccionService {
  baseUrl = environment.apiUrl;

  _idLineaCarrera: any = '';
  _idNivel: any = '';
  _search: any = '';

constructor(private http: HttpClient) { }

getLecciones(idEtapa, idCurso, idLineaCarrera, idNivel, search): Observable<Leccion[]>  {
  this._idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this._idLineaCarrera;
  this._idNivel = (idNivel != null) ? idNivel : this._idNivel;
  this._search = (search != null) ? search : this._search;
  return this.http.get<Leccion[]>(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones',
  { params: { idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search } });
}

getLeccion(idEtapa, idCurso, idLeccion): Observable<Leccion>  {
  return this.http.get<Leccion>(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones/' + idLeccion);
}

createLeccion(idEtapa, idCurso, leccion: LeccionToRegister) {
  return this.http.post(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones/', leccion);
}

editLeccion(idEtapa, idCurso, idLeccion, leccion: LeccionToRegister) {
  return this.http.put(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones/' + idLeccion, leccion);
}

deleteLeccion(idEtapa, idCurso, idLeccion) {
  return this.http.delete(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones/' + idLeccion);
}

getLeccionMateriales(idEtapa, idCurso, idLeccion): Observable<LeccionMaterialLite[]>  {
  return this.http.get<LeccionMaterialLite[]>(this.baseUrl + 'etapas/' + idEtapa +
  '/cursos/' + idCurso + '/lecciones/' + idLeccion + '/lecciones-material',
  { params: { idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search } });
}

getLeccionMaterial(idEtapa, idCurso, idLeccion, idLeccionMaterial): Observable<LeccionMaterial[]>  {
  return this.http.get<LeccionMaterial[]>(this.baseUrl + 'etapas/' + idEtapa +
   '/cursos/' + idCurso + '/lecciones/' + idLeccion + '/lecciones-material/' + idLeccionMaterial);
}

createLeccionMaterial(idEtapa, idCurso, idLeccion, leccionMaterial: LeccionMaterial) {
  return this.http.post(this.baseUrl + 'etapas/' + idEtapa +
   '/cursos/' + idCurso + '/lecciones/' + idLeccion  + '/lecciones-material', leccionMaterial);
}

editLeccionMaterial(idEtapa, idCurso, idLeccion, idLeccionMaterial, leccionMaterial: LeccionMaterial) {
  return this.http.put(this.baseUrl + 'etapas/' + idEtapa +
  '/cursos/' + idCurso + '/lecciones/' + idLeccion  + '/lecciones-material/' + idLeccionMaterial, leccionMaterial);
}

deleteLeccionMaterial(idEtapa, idCurso, idLeccion, idLeccionMaterial) {
  return this.http.delete(this.baseUrl + 'etapas/' + idEtapa +
  '/cursos/' + idCurso + '/lecciones/' + idLeccion + '/lecciones-material/' + idLeccionMaterial);
}

getVideo(idEtapa, idCurso, idLeccion, idLeccionMaterial) {
  return this.http.get<Video>(this.baseUrl + 'etapas/' + idEtapa +
   '/cursos/' + idCurso + '/lecciones/' + idLeccion + '/lecciones-material/videos/' + idLeccionMaterial);
}

}
