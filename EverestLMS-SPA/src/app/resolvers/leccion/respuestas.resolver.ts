import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of  } from 'rxjs';
import { Respuesta } from 'src/app/models/respuesta';

@Injectable()
export class RespuestasResolver implements Resolve<Respuesta[]> {

    constructor(private service: LeccionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Respuesta[]> {
        var idPregunta = (route.params['idPregunta'] ?? 0) == '' ? 0 : route.params['idPregunta'];
        return this.service.getRespuestas(route.params['idEtapa'], route.params['idCurso'], route.params['idLeccion'], idPregunta).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/lecciones']);
                return of(null);
            })
        );
    }
}
