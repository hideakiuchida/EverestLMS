import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Idioma } from 'src/app/models/idioma';
import { IdiomaService } from 'src/app/services/idioma/idioma.service';

@Injectable()
export class IdiomaResolver implements Resolve<Idioma[]> {

    constructor(private service: IdiomaService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Idioma[]> {
        return this.service.getIdiomas().pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
