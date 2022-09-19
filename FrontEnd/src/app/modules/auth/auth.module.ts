import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { SignUpComponent } from './sign-up/sign-up.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LoginPassComponent } from './login-pass/login-pass.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
import { RequestPasswordComponent } from './request-password/request-password.component';
import { NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';

const routes: Routes = [
  {
    path: '',
    component: AuthComponent,
    children: [
      {
        path: '',
        redirectTo: 'login',
        pathMatch: 'full'
      },
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'login-pass',
        component: LoginPassComponent
      },
      {
        path: 'sign-up',
        component: SignUpComponent
      }
    ]
  },
]

@NgModule({
  declarations: [LoginComponent, SignUpComponent, AuthComponent, LoginFormComponent, LoginPassComponent, ResetPasswordComponent, RequestPasswordComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FontAwesomeModule,
    ReactiveFormsModule,
    NgbAlertModule
  ]
})
export class AuthModule { }
