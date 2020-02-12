import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Idioma } from 'src/app/models/idioma';

@Injectable({
  providedIn: 'root'
})
export class IdiomaService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getIdiomas(): Observable<Idioma[]> {
    return this.http.get<Idioma[]>(this.baseUrl + 'idiomas');
  }
}
