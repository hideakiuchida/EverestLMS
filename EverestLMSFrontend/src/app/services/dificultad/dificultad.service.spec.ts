/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { DificultadService } from './dificultad.service';

describe('Service: Dificultad', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [DificultadService]
    });
  });

  it('should ...', inject([DificultadService], (service: DificultadService) => {
    expect(service).toBeTruthy();
  }));
});
