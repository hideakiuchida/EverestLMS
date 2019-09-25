/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { IdiomaService } from './idioma.service';

describe('Service: Idioma', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IdiomaService]
    });
  });

  it('should ...', inject([IdiomaService], (service: IdiomaService) => {
    expect(service).toBeTruthy();
  }));
});
