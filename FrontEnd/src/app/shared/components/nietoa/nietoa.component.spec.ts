import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NietoaComponent } from './nietoa.component';

describe('NietoaComponent', () => {
  let component: NietoaComponent;
  let fixture: ComponentFixture<NietoaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NietoaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NietoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
