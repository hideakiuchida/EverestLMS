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
    if (idNivel != null) {
        this._idNivel = idNivel;
    }
    if (idLineaCarrera != null) {
        this._idLineaCarrera = idLineaCarrera;
    }
    if (search != null) {
        this._search = search;
    }
    return this.http.get<SherpaLite[]>(this.baseUrl + 'participante/sherpaslite',
    { params: {idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search}});
}

getSherpa(id): Observable<Sherpa> {
    return this.http.get<Sherpa>(this.baseUrl + 'participante/sherpa/' + id);
}

getEscalador(id): Observable<Escalador> {
    return this.http.get<Escalador>(this.baseUrl + 'participante/escalador/' + id);
}

}
