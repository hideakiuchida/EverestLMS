import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LineaCarreraService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getLineaCarreras(): Observable<LineaCarrera[]> {
    return this.http.get<LineaCarrera[]>(this.baseUrl + 'lineacarrera');
  }

}
