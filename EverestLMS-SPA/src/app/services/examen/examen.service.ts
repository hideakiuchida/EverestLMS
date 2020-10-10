import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Examen } from 'src/app/models/examen';
import { ExamenToUpdate } from 'src/app/models/examenToUpdate';
import { PreguntaExamen } from 'src/app/models/preguntaExamen';
import { RespuestaEscaladorToUpdate } from 'src/app/models/respuestaEscaladorToUpdate';
import { environment } from 'src/environments/environment';

@Injectable()
export class ExamenService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createExamenPorCurso(usuarioKey, idCurso): Observable<number> {
    const requestBody = {usuarioKey, idCurso};
    return this.http.post<number>(this.baseUrl + 'examenes/curso', requestBody);
  }

  createExamenPorLeccion(usuarioKey, idCurso, idLeccion): Observable<number> {
    const requestBody = {usuarioKey, idCurso, idLeccion};
    return this.http.post<number>(this.baseUrl + 'examenes/leccion', requestBody);
  }

  updateExamen(idExamen, examentToUpdate: ExamenToUpdate): Observable<boolean> {
    return this.http.put<boolean>(this.baseUrl + 'examenes/' + idExamen, examentToUpdate);
  }

  updateEscaladorRespuestas(idExamen, idRespuesta, respuestaToUpdate: RespuestaEscaladorToUpdate): Observable<boolean> {
    return this.http.put<boolean>(this.baseUrl + 'examenes/' + idExamen + '/escalador-respuestas/' + idRespuesta, respuestaToUpdate);
}

  getExamen(idExamen): Observable<Examen>  {
    return this.http.get<Examen>(this.baseUrl + 'examenes/' + idExamen);
  }

  getPregunta(idExamen): Observable<PreguntaExamen>  {
    return this.http.get<PreguntaExamen>(this.baseUrl + 'examenes/' + idExamen + '/pregunta');
  }
}
