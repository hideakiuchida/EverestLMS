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
        const idEtapa = route.params.idEtapa;
        const idCurso = route.params.idCurso;
        const idLeccion = route.params.idLeccion;
        const idParticipante = route.params.idParticipante;
        if (idLeccion != null) {
            return this.examenService
            .createExamenPorLeccion(idParticipante, +idEtapa, +idCurso, +idLeccion)
            .pipe(
                catchError(error => {
                    if (error.error.text === undefined) {
                        this.alertify.error(error.error);
                    } else {
                        this.alertify.error(error.error.text);
                    }
                    this.router.navigate(['/leccion-participante/', idParticipante, idEtapa, idCurso, idLeccion]);
                    return of(null);
                })
            );
        } else {
            return this.examenService
            .createExamenPorCurso(idParticipante, +idEtapa, +idCurso)
            .pipe(
                catchError(error => {
                    if (error.error.text === undefined) {
                        this.alertify.error(error.error);
                    } else {
                        this.alertify.error(error.error.text);
                    }
                    this.router.navigate(['/curso-participante/' + idParticipante, idEtapa, idCurso]);
                    return of(null);
                })
            );
        }
    }
}
