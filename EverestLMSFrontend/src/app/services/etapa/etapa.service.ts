import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Etapa } from 'src/app/models/etapa';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EtapaService {
  baseUrl = environment.apiUrl;

  _idLineaCarrera: any = '';
  _idNivel: any = '';
  _search: any = '';

constructor(private http: HttpClient) { }

getEtapas(idLineaCarrera, idNivel, search): Observable<Etapa[]>  {
  this._idLineaCarrera = (idLineaCarrera != null) ? idLineaCarrera : this._idLineaCarrera;
  this._idNivel = (idNivel != null) ? idNivel : this._idNivel;
  this._search = (search != null) ? search : this._search;
  return this.http.get<Etapa[]>(this.baseUrl + 'etapas' ,
  { params: { idNivel: this._idNivel, idLineaCarrera: this._idLineaCarrera, search: this._search } });
}

}
