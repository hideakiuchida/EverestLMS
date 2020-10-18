import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Examen } from 'src/app/models/examen';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ExamenService } from 'src/app/services/examen/examen.service';

@Injectable()
export class ExamenResolver implements Resolve<Examen> {

    constructor(private examenService: ExamenService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Examen> {
        const idExamen = route.params.idExamen;
        const idParticipante = route.params.idParticipante;
        return this.examenService
        .getExamen(+idExamen)
        .pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-cursos/' + idParticipante]);
                return of(null);
            })
        );
    }
}
