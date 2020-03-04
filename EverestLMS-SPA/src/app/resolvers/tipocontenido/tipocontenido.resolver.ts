import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { TipoContenido } from 'src/app/models/tipocontenido';
import { TipocontenidoService } from 'src/app/services/tipocontenido/tipocontenido.service';

@Injectable()
export class TipoContenidoResolver implements Resolve<TipoContenido[]> {

    constructor(private service: TipocontenidoService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<TipoContenido[]> {
        return this.service.getTiposContenido().pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}

