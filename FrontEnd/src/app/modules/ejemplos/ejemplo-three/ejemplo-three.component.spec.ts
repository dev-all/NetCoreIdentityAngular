import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploThreeComponent } from './ejemplo-three.component';

describe('EjemploThreeComponent', () => {
  let component: EjemploThreeComponent;
  let fixture: ComponentFixture<EjemploThreeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploThreeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploThreeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
