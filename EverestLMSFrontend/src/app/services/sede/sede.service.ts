import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Sede } from 'src/app/models/sede';

@Injectable({
  providedIn: 'root'
})
export class SedeService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getSedes(): Observable<Sede[]> {
    return this.http.get<Sede[]>(this.baseUrl + 'sedes');
  }

}
