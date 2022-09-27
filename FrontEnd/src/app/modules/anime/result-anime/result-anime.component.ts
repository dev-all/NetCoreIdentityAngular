import { Component, OnDestroy, OnInit } from '@angular/core';
import { Anime, MyAnime } from '@data/interfaces/api-anime';
import { AnimeService } from '@data/services/anime-api/anime.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-result-anime',
  templateUrl: './result-anime.component.html',
  styleUrls: ['./result-anime.component.scss'],
})
export class ResultAnimeComponent implements OnInit, OnDestroy {
  //var global
  anime_results: Anime[] = [];
  animeSubscription!: Subscription;

  constructor(private animeService: AnimeService) {}

  ngOnDestroy(): void {
    this.animeSubscription.unsubscribe;
  }

  ngOnInit(): void {
    // aqui se subscribe al servicio que es quien comparte el rultado
    this.animeSubscription = this.animeService
      .getResultAnime()
      .subscribe(result => {
        //console.log('estoy en result-anime-componet', result);
        this.anime_results = result;
      });
  }

  addAnime(anime: Anime) {
    //console.log(anime);

    const addAnime: MyAnime = {
      id: anime.mal_id,
      title: anime.title,
      image: anime.images['jpg'].image_url,
      total_episodes: anime.episodes,
      watched_episodes: 0,
    };

    this.animeService.animeSelected(addAnime);

    this.anime_results = [];
  }
}
