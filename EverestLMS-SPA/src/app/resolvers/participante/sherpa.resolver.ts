import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { ParticipanteService } from 'src/app/services/participante/participante.service';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Sherpa } from 'src/app/models/sherpa';

@Injectable()
export class SherpaResolver implements Resolve<Sherpa> {

    constructor(private participanteService: ParticipanteService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Sherpa> {
        return this.participanteService.getSherpa(route.params['idSherpa']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/home']);
                return of(null);
            })
        );
    }
}
