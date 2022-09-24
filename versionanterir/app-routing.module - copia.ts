import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guard/auth.guard';
import { BaseComponent } from '@layout/base/base.component';
import { ErrorPageComponent } from '@modules/error-page/error-page.component';

const routes: Routes = [
  {
    path:'auth', 
    loadChildren: () => import('@modules/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: '',
    component: BaseComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        loadChildren: () => import('@modules/user/user.module').then((m) => m.UserModule)
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
        path: 'general',
        loadChildren: () => import('@modules/general/general.module').then(m => m.GeneralModule)
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
    component: ErrorPageComponent,
    data: {
      'type': 404,
      'title': 'Page Not Found',
      'desc': 'Oopps!! The page you were looking for doesn\'t exist.'
    }
  },
  {
    path: 'error/:type',
    component: ErrorPageComponent
  },
  { path: '**', redirectTo: 'error', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
