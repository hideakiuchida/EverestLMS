import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { CursosService } from 'src/app/services/curso/cursos.service';
import { Imagen } from 'src/app/models/imagen';

@Injectable()
export class CursoImagenResolver implements Resolve<Imagen[]> {

    constructor(private service: CursosService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Imagen[]> {
        return this.service.getImagenes(route.params['idEtapa'], route.params['idCurso']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/cursos']);
                return of(null);
            })
        );
    }
}
