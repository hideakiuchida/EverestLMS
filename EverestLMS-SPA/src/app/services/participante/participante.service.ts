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

  idNivel: any = '';
  idLineaCarrera: any = '';
  idSede: any = '';
  search: any = '';

constructor(private http: HttpClient) { }

getSherpas(idNivel, idLineaCarrera, idSede, search): Observable<SherpaLite[]> {

    this.idNivel = (idNivel != null) ? idNivel : this.idNivel;
    this.idSede = (idSede != null) ? idSede : this.idSede;
    this.idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this.idLineaCarrera;
    this.search = (search != null) ? search : this.search;

    return this.http.get<SherpaLite[]>(this.baseUrl + 'participantes/sherpas',
    { params: {idNivel: this.idNivel, idLineaCarrera: this.idLineaCarrera, idSede: this.idSede, search: this.search}});
}

getSherpa(id): Observable<Sherpa> {
    return this.http.get<Sherpa>(this.baseUrl + 'participantes/sherpas/' + id);
}

getEscalador(id): Observable<Escalador> {
    return this.http.get<Escalador>(this.baseUrl + 'participantes/escaladores/' + id);
}

updatePuntaje(id, puntaje): Observable<boolean> {
  const requestToUpdate =  { Id: id, Puntaje: puntaje};
  return this.http.patch<boolean>(this.baseUrl + 'participantes/actualizar-puntaje/', requestToUpdate);
}

}
