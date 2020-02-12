import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Curso } from 'src/app/models/curso';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CursoParticipanteService {
  baseUrl = environment.apiUrl;

  _idEtapa: any = '';
  _idIdioma: any = '';

constructor(private http: HttpClient) { }

getCursosPorParticipante(idParticipante, idEtapa, idIdioma): Observable<Curso[]>  {
  this._idEtapa = (idEtapa != null) ? idEtapa : this._idEtapa;
  this._idIdioma = (idIdioma != null) ? idIdioma : this._idIdioma;
  return this.http.get<Curso[]>(this.baseUrl + 'participantes/' + idParticipante + '/cursos',
  { params: { idEtapa: this._idEtapa,  idIdioma: this._idIdioma } });
}

getCursosPrediccionPorParticipante(idParticipante, idEtapa, idIdioma): Observable<Curso[]>  {
  this._idEtapa = (idEtapa != null) ? idEtapa : this._idEtapa;
  this._idIdioma = (idIdioma != null) ? idIdioma : this._idIdioma;
  return this.http.get<Curso[]>(this.baseUrl + 'participantes/' + idParticipante + '/cursos/predicciones',
  { params: { idEtapa: this._idEtapa,  idIdioma: this._idIdioma } });
}


}
