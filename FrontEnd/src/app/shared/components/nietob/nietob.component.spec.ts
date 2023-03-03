import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NietobComponent } from './nietob.component';

describe('NietobComponent', () => {
  let component: NietobComponent;
  let fixture: ComponentFixture<NietobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NietobComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NietobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
