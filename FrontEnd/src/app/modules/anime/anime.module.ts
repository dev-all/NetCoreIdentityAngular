import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AnimeComponent } from './anime.component';
import { SearchAnimeComponent } from './search-anime/search-anime.component';
import { ResultAnimeComponent } from './result-anime/result-anime.component';
import { SelectedAnimeComponent } from './selected-anime/selected-anime.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';

const routes: Routes = [
  {
    path: '',
    component: AnimeComponent,
    children: [
      {
        path: '',
        redirectTo: 'Shearch',
        pathMatch: 'full', /// esta propiedad es para redirigir exactamente a la propiedad redirectTo
      },
    ],
  },
];
@NgModule({
  declarations: [
    AnimeComponent,
    SearchAnimeComponent,
    ResultAnimeComponent,
    SelectedAnimeComponent,
  ],
  imports: [CommonModule, RouterModule.forChild(routes), FormsModule],
})
export class AnimeModule {}
