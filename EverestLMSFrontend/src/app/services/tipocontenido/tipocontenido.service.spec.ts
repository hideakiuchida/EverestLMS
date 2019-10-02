/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { TipocontenidoService } from './tipocontenido.service';

describe('Service: Tipocontenido', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TipocontenidoService]
    });
  });

  it('should ...', inject([TipocontenidoService], (service: TipocontenidoService) => {
    expect(service).toBeTruthy();
  }));
});
