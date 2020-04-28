import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { Injectable } from '@angular/core';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { catchError } from 'rxjs/operators';
import { Observable, of  } from 'rxjs';
import { Respuesta } from 'src/app/models/respuesta';

@Injectable()
export class RespuestaResolver implements Resolve<Respuesta> {

    constructor(private service: LeccionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Respuesta> {
        var idRespuesta = (route.params['idRespuesta'] ?? 0) == '' ? 0 : route.params['idRespuesta'];
        return this.service.getRespuesta(route.params['idEtapa'], route.params['idCurso'], route.params['idLeccion'], route.params['idPregunta'], idRespuesta).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/actualizar-pregunta']);
                return of(null);
            })
        );
    }
}
