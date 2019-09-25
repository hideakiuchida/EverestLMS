import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Dificultad } from 'src/app/models/dificultad';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DificultadService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getDificultades(): Observable<Dificultad[]> {
    return this.http.get<Dificultad[]>(this.baseUrl + 'dificultades');
  }

}
