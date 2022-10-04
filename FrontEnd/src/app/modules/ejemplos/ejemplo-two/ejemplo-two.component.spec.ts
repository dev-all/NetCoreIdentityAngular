import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploTwoComponent } from './ejemplo-two.component';

describe('EjemploTwoComponent', () => {
  let component: EjemploTwoComponent;
  let fixture: ComponentFixture<EjemploTwoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploTwoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploTwoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
