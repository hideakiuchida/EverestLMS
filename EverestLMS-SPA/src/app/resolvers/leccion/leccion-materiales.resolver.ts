import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LeccionService } from 'src/app/services/leccion/leccion.service';
import { LeccionMaterial } from 'src/app/models/leccionMaterial';

@Injectable()
export class LeccionMaterialesResolver implements Resolve<LeccionMaterial[]> {

    constructor(private service: LeccionService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<LeccionMaterial[]> {
        return this.service.getLeccionMateriales(route.params['idEtapa'], route.params['idCurso'],
         route.params['idLeccion']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/lecciones']);
                return of(null);
            })
        );
    }
}
