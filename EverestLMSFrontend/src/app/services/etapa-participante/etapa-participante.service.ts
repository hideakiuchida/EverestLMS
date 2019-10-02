import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Etapa } from 'src/app/models/etapa';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EtapaParticipanteService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getEtapasPorParticipante(idParticipante): Observable<Etapa[]>  {
  return this.http.get<Etapa[]>(this.baseUrl + 'participantes/' + idParticipante + '/etapas');
}

}
