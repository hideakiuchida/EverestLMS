import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { EscaladorLite } from 'src/app/models/escaladorLite';
import { Observable } from 'rxjs';
import { Mensaje } from 'src/app/models/mensaje';

@Injectable({
  providedIn: 'root'
})
export class AsignacionService {
  baseUrl = environment.apiUrl;

  _idLineaCarrera: any = '';
  _search: any = '';

  constructor(private http: HttpClient) { }

  getEscaladoresNoAsignados(idLineaCarrera, search): Observable<EscaladorLite[]> {

    this._idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this._idLineaCarrera;
    this._search = (search != null) ? search : this._search;

    return this.http.get<EscaladorLite[]>(this.baseUrl + 'participantes/escaladores-no-asignados',
      { params: { idLineaCarrera: this._idLineaCarrera, search: this._search } });
  }

  asignar(idSherpa, idEscalador) {
    const model = {idSherpa: idSherpa, idEscalador: idEscalador};
    return this.http.patch<Mensaje>(this.baseUrl + 'participantes/asignacion-manual', model);
  }

  desasignar(idSherpa, idEscalador) {
    const model = {idSherpa: idSherpa, idEscalador: idEscalador};
    return this.http.patch<Mensaje>(this.baseUrl + 'participantes/desasignacion-manual', model);
  }

  asignarAutomaticamente() {
    const model = {};
    return this.http.post<Mensaje>(this.baseUrl + 'participantes/asignacion-automatica', model);
  }
  desasignarAutomaticamente() {
    const model = {};
    return this.http.post<Mensaje>(this.baseUrl + 'participantes/desasignacion-automatica', model);
  }
}
