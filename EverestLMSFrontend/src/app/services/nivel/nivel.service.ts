import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Nivel } from 'src/app/models/nivel';

@Injectable({
  providedIn: 'root'
})
export class NivelService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getNiveles(): Observable<Nivel[]> {
    return this.http.get<Nivel[]>(this.baseUrl + 'nivel');
  }

}
