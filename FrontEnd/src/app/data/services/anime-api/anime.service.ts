import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Anime, APIAnime, MyAnime } from '@data/interfaces/api-anime';
import { Observable, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AnimeService {
  private API_URL = 'https://api.jikan.moe/v4/anime?q=';

  private anime_response$ = new Subject<Anime[]>();
  private anime_selected$ = new Subject<MyAnime>();

  constructor(protected http: HttpClient) {}

  getAnimes(searchTerm: string): Observable<APIAnime> {
    //1
    //const url = this.API_URL + searchTerm;

    //2
    //const url = ;
    //console.log(url);

    return this.http.get<APIAnime>(`${this.API_URL}${searchTerm}`);
  }

  //1
  addResultAnime(anime: Anime[]) {
    this.anime_response$.next(anime);
  }

  //2
  getResultAnime(): Observable<Anime[]> {
    return this.anime_response$.asObservable();
  }

  //3
  animeSelected(anime: MyAnime) {
    this.anime_selected$.next(anime);
  }

  getAnimeSelected(): Observable<MyAnime> {
    return this.anime_selected$.asObservable();
  }
}
