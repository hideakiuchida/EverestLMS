/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { CriterioAceptacionComponent } from './criterioaceptacion.component';

describe('CriterioaceptacionComponent', () => {
  let component: CriterioAceptacionComponent;
  let fixture: ComponentFixture<CriterioAceptacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CriterioAceptacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CriterioAceptacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
