import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LineaCarrera } from 'src/app/models/lineacarrera';
import { LineaCarreraService } from 'src/app/services/lineacarrera/lineacarrera.service';

@Injectable()
export class LineaCarreraResolver implements Resolve<LineaCarrera[]> {

    constructor(private service: LineaCarreraService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<LineaCarrera[]> {
        return this.service.getLineaCarreras().pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
