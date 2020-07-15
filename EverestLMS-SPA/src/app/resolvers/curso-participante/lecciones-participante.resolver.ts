import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Leccion } from 'src/app/models/leccion';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';

@Injectable()
export class LeccionesParticipanteResolver implements Resolve<Leccion[]> {

    constructor(private service: CursoParticipanteService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Leccion[]> {
        // tslint:disable-next-line:no-string-literal
        return this.service.getLeccionesPorCursoParticipante(route.params['idParticipante'], route.params['idCurso']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-cursos']);
                return of(null);
            })
        );
    }
}
