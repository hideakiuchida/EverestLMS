import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Nivel } from 'src/app/models/nivel';
import { NivelService } from 'src/app/services/nivel/nivel.service';

@Injectable()
export class NivelResolver implements Resolve<Nivel[]> {

    constructor(private service: NivelService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Nivel[]> {
        return this.service.getNiveles().pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}

