/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { AsignacionService } from './asignacion.service';

describe('Service: Asignacion', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AsignacionService]
    });
  });

  it('should ...', inject([AsignacionService], (service: AsignacionService) => {
    expect(service).toBeTruthy();
  }));
});
