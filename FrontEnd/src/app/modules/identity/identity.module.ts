import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SignUpIdentityComponent } from './sign-up-identity/sign-up-identity.component';
import { SignInIdentityComponent } from './sign-in-identity/sign-in-identity.component';
import { IdentityComponent } from './identity.component';
import { NoAuthGuard } from '@core/guard/no-auth.guard';

const routes: Routes = [
  
      {
        path: '',
        redirectTo: 'sign-in',
        pathMatch: 'full'
      },
      {
        path: 'sing-in',
        component: SignInIdentityComponent,
        canActivate :[NoAuthGuard]  
      },
      {
        path: 'sing-up',
        component: SignUpIdentityComponent,
        canActivate:[NoAuthGuard]
      }

]
@NgModule({
  declarations: [ IdentityComponent,SignUpIdentityComponent, SignInIdentityComponent ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),

  ]
})

export class IdentityModule { }
