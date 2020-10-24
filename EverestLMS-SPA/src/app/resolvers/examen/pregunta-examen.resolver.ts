import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { PreguntaExamen } from 'src/app/models/preguntaExamen';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ExamenService } from 'src/app/services/examen/examen.service';

@Injectable()
export class PreguntaExamenResolver implements Resolve<PreguntaExamen> {

    constructor(private examenService: ExamenService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<PreguntaExamen> {
        return this.examenService.getPregunta(route.params.idExamen, route.params.numeroPregunta).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-examen' + route.params.idParticipante]);
                return of(null);
            })
        );
    }
}
