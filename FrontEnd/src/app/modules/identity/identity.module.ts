import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpIdentityComponent } from './sign-up-identity/sign-up-identity.component';
import { SignInIdentityComponent } from './sign-in-identity/sign-in-identity.component';

const routes: Routes = [
  {
    path: '',
    component: SignInIdentityComponent,
    children: [
      {
        path: '',
        redirectTo: 'sign-in',
        pathMatch: 'full'
      },
      {
        path: 'sing-in',
        component: SignInIdentityComponent
      },
      {
        path: 'sing-up',
        component: SignUpIdentityComponent
      }

    ]
  }
]
@NgModule({
  declarations: [SignUpIdentityComponent, SignInIdentityComponent ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),

  ]
})

export class IdentityModule { }
