import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TipoContenido } from 'src/app/models/tipocontenido';

@Injectable({
  providedIn: 'root'
})
export class TipocontenidoService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getTiposContenido(): Observable<TipoContenido[]> {
    return this.http.get<TipoContenido[]>(this.baseUrl + 'tipos-contenido');
  }
}
