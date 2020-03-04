import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CriterioAceptacion } from 'src/app/models/criterioaceptacion';
import { CalendarioService } from 'src/app/services/calendario/calendario.service';

@Injectable()
export class CriteriosAceptacionResolver implements Resolve<CriterioAceptacion[]> {

    constructor(private calendarioService: CalendarioService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<CriterioAceptacion[]> {
        // tslint:disable-next-line:no-string-literal
        return this.calendarioService.getCriteriosAceptacion(route.params['idCalendario']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/calendario']);
                return of(null);
            })
        );
    }
}
