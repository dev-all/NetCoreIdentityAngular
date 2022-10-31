import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guard/auth.guard';
import { INTERNAL_PATHS, INTERNAL_ROUTES } from '@data/constants/routes';
import { BaseComponent } from '@layout/base/base.component';
import { ErrorPageComponent } from '@modules/error-page/error-page.component';

const routes: Routes = [

  {
    path: '',
    redirectTo: INTERNAL_ROUTES.AUTH_LOGIN,     
    pathMatch:'full'
  },
  {
    path:'auth',
    loadChildren: () => import('@modules/auth/auth.module').then(m => m.AuthModule)
  },

  {
    path:'identity',
    loadChildren: () => import('@modules/identity/identity.module').then(m => m.IdentityModule)
  },

  {
    path: '',
    component: BaseComponent,
    canActivate: [AuthGuard],
    children: [              
      {
        path: 'general',
        loadChildren: () => import('@modules/general/general.module').then(m => m.GeneralModule)
      },   
      {
        path: 'ejemplos',
        loadChildren: () => import('@modules/ejemplos/ejemplos.module').then(m => m.EjemplosModule)
      },
      {
        path: 'user',
        loadChildren: () => import('@modules/user/user.module').then(m => m.UserModule)
      },      
      {
        path: 'anime',
        loadChildren: () => import('@modules/anime/anime.module').then(m => m.AnimeModule)
      },
      {
        path: 'form-elements',
        loadChildren:()=> import('@modules/form-elements/form-elements.module').then(m => m.FormElementsModule)
      },
      {
        path: 'advanced-form-elements',
        loadChildren: () => import('@modules/advanced-form-elements/advanced-form-elements.module').then(m => m.AdvancedFormElementsModule)
      }
    ]
  },
  {
    path: 'error',
    component: ErrorPageComponent
    
  },
  {
    path: 'error/:type',
    component: ErrorPageComponent ,
    data: {
      'type': 404,
      'title': 'Page Not Found',
      'desc': 'Oopps!! The page you were looking for doesn\'t exist.'
    }   
  },
  { path: '**', redirectTo: 'error', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
