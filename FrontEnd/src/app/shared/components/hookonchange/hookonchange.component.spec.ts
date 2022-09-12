import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HookonchangeComponent } from './hookonchange.component';

describe('HookonchangeComponent', () => {
  let component: HookonchangeComponent;
  let fixture: ComponentFixture<HookonchangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HookonchangeComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HookonchangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
