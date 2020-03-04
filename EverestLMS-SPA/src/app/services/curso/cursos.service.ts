import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Curso } from 'src/app/models/curso';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { CursoToRegister } from 'src/app/models/cursoToRegister';
import { Imagen } from 'src/app/models/imagen';

@Injectable({
  providedIn: 'root'
})
export class CursosService {
  baseUrl = environment.apiUrl;

  // tslint:disable-next-line:variable-name
  _idLineaCarrera: any = '';
  // tslint:disable-next-line:variable-name
  _idNivel: any = '';
  // tslint:disable-next-line:variable-name
  _search: any = '';

constructor(private http: HttpClient) { }

getCursos(idEtapa, idLineaCarrera, idNivel, search): Observable<Curso[]>  {
  this._idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this._idLineaCarrera;
  this._idNivel = (idNivel != null) ? idNivel : this._idNivel;
  this._search = (search != null) ? search : this._search;
  return this.http.get<Curso[]>(this.baseUrl + 'etapas/' + idEtapa + '/cursos',
  { params: { idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search } });
}

getCurso(idEtapa, idCurso): Observable<Curso[]>  {
  return this.http.get<Curso[]>(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso);
}

createCurso(idEtapa, curso: CursoToRegister) {
  return this.http.post(this.baseUrl + 'etapas/' + idEtapa + '/cursos', curso);
}

editCurso(idEtapa, idCurso, curso: CursoToRegister) {
  return this.http.put(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso, curso);
}

deleteCurso(idEtapa, idCurso) {
  return this.http.delete(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso);
}

getImagenes(idEtapa, idCurso) {
  return this.http.get<Imagen[]>(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/imagenes');
}

getImagen(idEtapa, idCurso, idImagen) {
  return this.http.get<Imagen>(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/imagenes/' + idImagen);
}

deleteImagen(idEtapa, idCurso, idImagen) {
  return this.http.delete(this.baseUrl + 'etapas/' + idEtapa + '/cursos/' + idCurso + '/imagenes/' + idImagen);
}
}
