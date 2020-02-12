/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LineacarreraService } from './lineacarrera.service';

describe('Service: Lineacarrera', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LineacarreraService]
    });
  });

  it('should ...', inject([LineacarreraService], (service: LineacarreraService) => {
    expect(service).toBeTruthy();
  }));
});
