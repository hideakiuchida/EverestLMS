/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { LeccionService } from './leccion.service';

describe('Service: Leccion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LeccionService]
    });
  });

  it('should ...', inject([LeccionService], (service: LeccionService) => {
    expect(service).toBeTruthy();
  }));
});
