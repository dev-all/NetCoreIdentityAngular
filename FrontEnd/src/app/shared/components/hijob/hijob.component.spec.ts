import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HijobComponent } from './hijob.component';

describe('HijobComponent', () => {
  let component: HijobComponent;
  let fixture: ComponentFixture<HijobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ HijobComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(HijobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
