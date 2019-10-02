import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Curso } from 'src/app/models/curso';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';

@Injectable()
export class CursosPrediccionParticipanteResolver implements Resolve<Curso[]> {

    constructor(private service: CursoParticipanteService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Curso[]> {
        return this.service.getCursosPrediccionPorParticipante(route.params['idParticipante'], null, null).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-cursos']);
                return of(null);
            })
        );
    }
}
