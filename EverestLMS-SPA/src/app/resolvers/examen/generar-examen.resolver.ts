import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { of } from 'rxjs/internal/observable/of';
import { catchError } from 'rxjs/operators';
import { Examen } from 'src/app/models/examen';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { ExamenService } from 'src/app/services/examen/examen.service';

@Injectable()
export class GenerarExamenResolver implements Resolve<Examen> {

    constructor(private examenService: ExamenService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Examen> {
        const idCurso = route.params.idCurso;
        const idLeccion = route.params.idLeccion;
        const idParticipante = route.params.idParticipante;
        if (idLeccion != null) {
            return this.examenService
            .createExamenPorLeccion(idParticipante, +idCurso, +idLeccion)
            .pipe(
                catchError(error => {
                    this.alertify.error('Problema obteniendo información.');
                    this.router.navigate(['/realizar-cursos/' + idParticipante]);
                    return of(null);
                })
            );
        } else {
            return this.examenService
            .createExamenPorCurso(idParticipante, +idCurso)
            .pipe(
                catchError(error => {
                    this.alertify.error('Problema obteniendo información.');
                    this.router.navigate(['/realizar-cursos/' + idParticipante]);
                    return of(null);
                })
            );
        }
    }
}
