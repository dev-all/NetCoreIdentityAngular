import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FtTheadComponent } from './ft-thead.component';

describe('FtTheadComponent', () => {
  let component: FtTheadComponent;
  let fixture: ComponentFixture<FtTheadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FtTheadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FtTheadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
