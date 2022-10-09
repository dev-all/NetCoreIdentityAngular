import { NgModule, Pipe } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EjemplosComponent } from './ejemplos.component';
import { PipesComponent } from './pipes/pipes.component';
import { InternacionalComponent } from './internacional/internacional.component';
import { SharedModule } from '@share/shared.module';
import { EjemploOneComponent } from './ejemplo-one/ejemplo-one.component';
import { AuthGuard } from '@core/guard/auth.guard';
import { EjemploTwoComponent } from './ejemplo-two/ejemplo-two.component';
import { EjemploThreeComponent } from './ejemplo-three/ejemplo-three.component';
import { EjemploFourComponent } from './ejemplo-four/ejemplo-four.component';
import { EjemploFiveComponent } from './ejemplo-five/ejemplo-five.component';


const routes: Routes = [
  {
    path: '',
    component: EjemplosComponent,
    children: [
      {
        path: '',
        redirectTo: 'pipes',
        pathMatch: 'full'      /// esta propiedad es para redirigir exactamente a la propiedad redirectTo
      },
      {
        path: 'pipes',
        component: PipesComponent
      },
      {
        path: 'inter',
        component: InternacionalComponent
      },
      {
        path: 'one',
        component: EjemploOneComponent,
        canActivate :[AuthGuard] 
      },
      {
        path: 'two',
        component: EjemploTwoComponent,
        canActivate :[AuthGuard] 
      },
      {
        path: 'three',
        component: EjemploThreeComponent,
        canActivate :[AuthGuard] 
      },
      {
        path: 'four',
        component: EjemploFourComponent,
        canActivate :[AuthGuard] 
      },
      {
        path: 'five',
        component: EjemploFiveComponent,
        canActivate :[AuthGuard] 
      },
    ]
  }
]

@NgModule({
  declarations: [EjemplosComponent,PipesComponent, InternacionalComponent, EjemploOneComponent, EjemploTwoComponent, EjemploThreeComponent, EjemploFourComponent, EjemploFiveComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    SharedModule
  ]
})
export class EjemplosModule { }
