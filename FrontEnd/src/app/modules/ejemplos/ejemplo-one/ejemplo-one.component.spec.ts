import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploOneComponent } from './ejemplo-one.component';

describe('EjemploOneComponent', () => {
  let component: EjemploOneComponent;
  let fixture: ComponentFixture<EjemploOneComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploOneComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploOneComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
