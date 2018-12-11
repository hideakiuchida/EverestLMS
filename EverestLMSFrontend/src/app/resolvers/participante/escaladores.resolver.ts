import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EscaladorLite } from 'src/app/models/escaladorLite';
import { AsignacionService } from 'src/app/services/asignacion/asignacion.service';

@Injectable()
export class EscaladoresResolver implements Resolve<EscaladorLite[]> {

    constructor(private asignacionService: AsignacionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<EscaladorLite[]> {
        return this.asignacionService.getEscaladoresNoAsignados(route.params['idLineaCarrera'], '').pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/asignarequipos']);
                return of(null);
            })
        );
    }
}
