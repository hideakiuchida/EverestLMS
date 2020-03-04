import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Dificultad } from 'src/app/models/dificultad';
import { DificultadService } from 'src/app/services/dificultad/dificultad.service';

@Injectable()
export class DificultadResolver implements Resolve<Dificultad[]> {

    constructor(private service: DificultadService,
                private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Dificultad[]> {
        return this.service.getDificultades().pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
