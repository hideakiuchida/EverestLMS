import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CursoParticipanteService } from 'src/app/services/curso-participante/curso-participante.service';
import { CursoDetalle } from 'src/app/models/cursoDetalle';

@Injectable()
export class CursoDetalleResolver implements Resolve<CursoDetalle[]> {

    constructor(private service: CursoParticipanteService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<CursoDetalle[]> {
        // tslint:disable-next-line:no-string-literal
        return this.service.getLeccionesPorCursoParticipante(route.params['idParticipante'], route.params['idEtapa'], route.params['idCurso']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-cursos']);
                return of(null);
            })
        );
    }
}
