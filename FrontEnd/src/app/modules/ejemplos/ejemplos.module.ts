import { NgModule, Pipe } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { EjemplosComponent } from './ejemplos.component';
import { PipesComponent } from './pipes/pipes.component';
import { InternacionalComponent } from './internacional/internacional.component';
import { SharedModule } from '@share/shared.module';

const routes: Routes = [
  {
    path: '',
    component: EjemplosComponent,
    children: [
      {
        path: '',
        redirectTo: 'pipes',
        pathMatch: 'full', /// esta propiedad es para redirigir exactamente a la propiedad redirectTo
      },
      {
        path: 'pipes',
        component: PipesComponent,
      },
      {
        path: 'inter',
        component: InternacionalComponent,
      },
    ],
  },
];

@NgModule({
  declarations: [EjemplosComponent, PipesComponent, InternacionalComponent],
  imports: [CommonModule, RouterModule.forChild(routes), SharedModule],
})
export class EjemplosModule {}
