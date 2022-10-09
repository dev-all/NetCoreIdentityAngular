import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploFiveComponent } from './ejemplo-five.component';

describe('EjemploFiveComponent', () => {
  let component: EjemploFiveComponent;
  let fixture: ComponentFixture<EjemploFiveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploFiveComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploFiveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
