import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EjemploSixComponent } from './ejemplo-six.component';

describe('EjemploSixComponent', () => {
  let component: EjemploSixComponent;
  let fixture: ComponentFixture<EjemploSixComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EjemploSixComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EjemploSixComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
