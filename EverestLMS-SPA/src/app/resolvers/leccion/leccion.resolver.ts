import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { LeccionService } from 'src/app/services/leccion/leccion.service';

@Injectable()
export class LeccionResolver implements Resolve<LeccionToRegister> {

    constructor(private service: LeccionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<LeccionToRegister> {
        return this.service.getLeccion(route.params['idEtapa'], route.params['idCurso'], route.params['idLeccion']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/lecciones']);
                return of(null);
            })
        );
    }
}
