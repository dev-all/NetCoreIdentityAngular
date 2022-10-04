import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploFourComponent } from './ejemplo-four.component';

describe('EjemploFourComponent', () => {
  let component: EjemploFourComponent;
  let fixture: ComponentFixture<EjemploFourComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploFourComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploFourComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
