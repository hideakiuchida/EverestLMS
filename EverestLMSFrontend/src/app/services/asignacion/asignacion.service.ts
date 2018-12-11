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
    if (idLineaCarrera != null) {
      this._idLineaCarrera = idLineaCarrera;
    }
    if (search != null) {
      this._search = search;
    }
    return this.http.get<EscaladorLite[]>(this.baseUrl + 'AsignacionEquipos/EscaladoresNoAsignados',
      { params: { idLineaCarrera: this._idLineaCarrera, search: this._search } });
  }

  asignar(idSherpa, idEscalador) {
    // tslint:disable-next-line:no-debugger
    debugger;
    const model = {idSherpa: idSherpa, idEscalador: idEscalador};
    return this.http.patch<Mensaje>(this.baseUrl + 'AsignacionEquipos/AsignacionManual', model);
  }

  desasignar(idSherpa, idEscalador) {
    const model = {idSherpa: idSherpa, idEscalador: idEscalador};
    return this.http.patch<Mensaje>(this.baseUrl + 'AsignacionEquipos/DesasignacionManual', model);
  }

  asignarAutomaticamente() {
    const model = {};
    return this.http.post<Mensaje>(this.baseUrl + 'AsignacionEquipos/AsignacionAutomatica', model);
  }
}
