import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SignInIdentityComponent } from './sign-in-identity.component';

describe('SignInIdentityComponent', () => {
  let component: SignInIdentityComponent;
  let fixture: ComponentFixture<SignInIdentityComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SignInIdentityComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SignInIdentityComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
