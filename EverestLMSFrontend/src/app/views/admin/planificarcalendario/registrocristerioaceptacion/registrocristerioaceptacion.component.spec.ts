/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { RegistrocristerioaceptacionComponent } from './registrocristerioaceptacion.component';

describe('RegistrocristerioaceptacionComponent', () => {
  let component: RegistrocristerioaceptacionComponent;
  let fixture: ComponentFixture<RegistrocristerioaceptacionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RegistrocristerioaceptacionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RegistrocristerioaceptacionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
