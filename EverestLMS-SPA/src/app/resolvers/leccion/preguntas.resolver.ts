import { Pregunta } from 'src/app/models/pregunta';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of  } from 'rxjs';

@Injectable()
export class PreguntasResolver implements Resolve<Pregunta[]> {

    constructor(private service: LeccionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Pregunta[]> {
        return this.service.getPreguntas(route.params['idEtapa'], route.params['idCurso'], route.params['idLeccion']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/lecciones']);
                return of(null);
            })
        );
    }
}
