import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FtTfootComponent } from './ft-tfoot.component';

describe('FtTfootComponent', () => {
  let component: FtTfootComponent;
  let fixture: ComponentFixture<FtTfootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FtTfootComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FtTfootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
