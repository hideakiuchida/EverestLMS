import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CursoToRegister } from 'src/app/models/cursoToRegister';
import { CursosService } from 'src/app/services/curso/cursos.service';

@Injectable()
export class CursoResolver implements Resolve<CursoToRegister> {

    constructor(private service: CursosService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<CursoToRegister> {
        // tslint:disable-next-line:no-string-literal
        return this.service.getCurso(route.params['idEtapa'], route.params['idCurso']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/cursos']);
                return of(null);
            })
        );
    }
}
