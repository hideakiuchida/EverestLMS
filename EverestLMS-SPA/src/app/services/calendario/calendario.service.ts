import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Calendario } from 'src/app/models/calendario';
import { Evento } from 'src/app/models/evento';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';

@Injectable({
  providedIn: 'root'
})
export class CalendarioService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

getCalendarios(): Observable<Calendario[]> {
  return this.http.get<Calendario[]>(this.baseUrl + 'calendarios');
}

getEventos(idCalendario): Observable<Evento[]> {
  return this.http.get<Evento[]>(this.baseUrl + 'calendarios/' + idCalendario + '/eventos');
}

createEvento(idCalendario, evento: Evento) {
  return this.http.post(this.baseUrl + 'calendarios/' + idCalendario + '/eventos', evento);
}

deleteEvento(idCalendario, idEvento) {
  return this.http.delete(this.baseUrl + 'calendarios/' + idCalendario + '/eventos/' + idEvento);
}

getCriteriosAceptacion(idCalendario): Observable<CriterioAceptacion[]> {
  return this.http.get<CriterioAceptacion[]>(this.baseUrl + 'calendarios/' + idCalendario + '/criterios-aceptacion');
}

createCriterioAceptacion(idCalendario, criterioAceptacion: CriterioAceptacion) {
  return this.http.post(this.baseUrl + 'calendarios/' + idCalendario + '/criterios-aceptacion', criterioAceptacion);
}

deleteCriterioAceptacion(idCalendario, idCriterioAceptacion) {
  return this.http.delete(this.baseUrl + 'calendarios/' + idCalendario + '/criterios-aceptacion/' + idCriterioAceptacion);
}
}
