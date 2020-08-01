import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LeccionEscalador } from 'src/app/models/leccionEscalador';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LeccionParticipanteService {
baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getLeccion(idParticipante, idEtapa, idCurso, idLeccion): Observable<LeccionEscalador>  {
  return this.http.get<LeccionEscalador>(this.baseUrl + 'participantes/' + idParticipante + '/etapas/' + idEtapa + '/cursos/' + idCurso + '/lecciones/' + idLeccion);
}
}
