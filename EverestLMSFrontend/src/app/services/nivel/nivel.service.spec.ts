/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { NivelService } from './nivel.service';

describe('Service: Nivel', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NivelService]
    });
  });

  it('should ...', inject([NivelService], (service: NivelService) => {
    expect(service).toBeTruthy();
  }));
});
