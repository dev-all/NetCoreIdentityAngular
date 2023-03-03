import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HijoaComponent } from './hijoa.component';

describe('HijoaComponent', () => {
  let component: HijoaComponent;
  let fixture: ComponentFixture<HijoaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HijoaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HijoaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
