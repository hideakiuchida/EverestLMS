/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { CursoParticipanteService } from './curso-participante.service';

describe('Service: CursoParticipante', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [CursoParticipanteService]
    });
  });

  it('should ...', inject([CursoParticipanteService], (service: CursoParticipanteService) => {
    expect(service).toBeTruthy();
  }));
});
