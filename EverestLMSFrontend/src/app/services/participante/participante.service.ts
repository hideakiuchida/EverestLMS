import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { SherpaLite } from 'src/app/models/sherpaLite';
import { Sherpa } from 'src/app/models/sherpa';
import { Escalador } from 'src/app/models/escalador';

@Injectable({
  providedIn: 'root'
})
export class ParticipanteService {
  baseUrl = environment.apiUrl;

  _idNivel: any = '';
  _idLineaCarrera: any = '';
  _search: any = '';

constructor(private http: HttpClient) { }

getSherpas(idNivel, idLineaCarrera, search): Observable<SherpaLite[]> {

    this._idNivel = (idNivel != null) ? idNivel : this._idNivel;
    this._idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this._idLineaCarrera;
    this._search = (search != null) ? search : this._search;

    return this.http.get<SherpaLite[]>(this.baseUrl + 'participantes/sherpas',
    { params: {idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search}});
}

getSherpa(id): Observable<Sherpa> {
    return this.http.get<Sherpa>(this.baseUrl + 'participantes/sherpas/' + id);
}

getEscalador(id): Observable<Escalador> {
    return this.http.get<Escalador>(this.baseUrl + 'participantes/escaladores/' + id);
}

}
