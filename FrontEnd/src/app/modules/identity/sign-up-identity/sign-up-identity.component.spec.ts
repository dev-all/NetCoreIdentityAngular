import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignUpIdentityComponent } from './sign-up-identity.component';

describe('SignUpIdentityComponent', () => {
  let component: SignUpIdentityComponent;
  let fixture: ComponentFixture<SignUpIdentityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignUpIdentityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignUpIdentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
