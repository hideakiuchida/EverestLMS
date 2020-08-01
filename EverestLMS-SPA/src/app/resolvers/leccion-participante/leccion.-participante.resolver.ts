import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LeccionToRegister } from 'src/app/models/leccionToRegister';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { LeccionEscalador } from 'src/app/models/leccionEscalador';
import { LeccionParticipanteService } from 'src/app/services/leccion-participante/leccion-participante.service';

@Injectable()
export class LeccionParticipanteResolver implements Resolve<LeccionEscalador> {

    constructor(private service: LeccionParticipanteService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<LeccionEscalador> {
        return this.service.getLeccion(route.params['idParticipante'], route.params['idEtapa'], route.params['idCurso'], route.params['idLeccion']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/curso-participante', route.params['idParticipante'], route.params['idEtapa'], route.params['idCurso']]);
                return of(null);
            })
        );
    }
}
