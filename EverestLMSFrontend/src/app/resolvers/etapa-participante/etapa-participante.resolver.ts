import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from 'src/app/services/alertify/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { EtapaParticipanteService } from 'src/app/services/etapa-participante/etapa-participante.service';
import { Etapa } from 'src/app/models/etapa';

@Injectable()
export class EtapasParticipanteResolver implements Resolve<Etapa[]> {

    constructor(private service: EtapaParticipanteService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Etapa[]> {
        return this.service.getEtapasPorParticipante(route.params['idParticipante']).pipe(
            catchError(error => {
                this.alertify.error('Problema obteniendo información.');
                this.router.navigate(['/realizar-cursos']);
                return of(null);
            })
        );
    }
}
