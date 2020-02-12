/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EtapaParticipanteService } from './etapa-participante.service';

describe('Service: EtapaParticipante', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EtapaParticipanteService]
    });
  });

  it('should ...', inject([EtapaParticipanteService], (service: EtapaParticipanteService) => {
    expect(service).toBeTruthy();
  }));
});
