import { Component, OnInit } from '@angular/core';
import { MyAnime } from '@data/interfaces/api-anime';
import { AnimeService } from '@data/services/anime-api/anime.service';

@Component({
  selector: 'app-selected-anime',
  templateUrl: './selected-anime.component.html',
  styleUrls: ['./selected-anime.component.scss'],
})
export class SelectedAnimeComponent implements OnInit {
  anime_selected: MyAnime[] = [];

  constructor(private animeService: AnimeService) {}

  ngOnInit(): void {
    this.anime_selected =
      JSON.parse(localStorage.getItem('my_anime') as any) || [];

    this.animeService.getAnimeSelected().subscribe(result => {
      // console.log(result);
      this.anime_selected.push(result);
      // guardo como json por si da f5 lo tengamos diponible es un ejemplo
      localStorage.setItem('my_anime', JSON.stringify(this.anime_selected));
    });
  }

  increaseWatch(anime: MyAnime) {
    anime.watched_episodes++; //espisodios vistos

    localStorage.setItem('my_anime', JSON.stringify(this.anime_selected));
  }

  decreaseWatch(anime: MyAnime) {
    anime.watched_episodes--; //espisodios vistos

    localStorage.setItem('my_anime', JSON.stringify(this.anime_selected));
  }
}
