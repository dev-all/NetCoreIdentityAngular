import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FtTbodyComponent } from './ft-tbody.component';

describe('FtTbodyComponent', () => {
  let component: FtTbodyComponent;
  let fixture: ComponentFixture<FtTbodyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FtTbodyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FtTbodyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
