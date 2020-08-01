/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LeccionParticipanteService } from './leccion-participante.service';

describe('Service: LeccionParticipante', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LeccionParticipanteService]
    });
  });

  it('should ...', inject([LeccionParticipanteService], (service: LeccionParticipanteService) => {
    expect(service).toBeTruthy();
  }));
});
