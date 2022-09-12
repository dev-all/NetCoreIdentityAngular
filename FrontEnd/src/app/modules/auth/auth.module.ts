import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { Routes, RouterModule } from '@angular/router';
import { AuthComponent } from './auth.component';
import { LoginFormComponent } from './login-form/login-form.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { LoginPassComponent } from './login-pass/login-pass.component';
import { ReactiveFormsModule } from '@angular/forms';

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
        path: 'register',
        component: RegisterComponent
      }
    ]
  },
]

@NgModule({
  declarations: [LoginComponent, RegisterComponent, AuthComponent, LoginFormComponent, LoginPassComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FontAwesomeModule,
    ReactiveFormsModule
  ]
})
export class AuthModule { }
