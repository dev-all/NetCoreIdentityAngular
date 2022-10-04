import { Component, OnInit } from '@angular/core';
import { MyAnime } from '@data/interfaces/api-anime';
import { AnimeService } from '@data/services/anime-api/anime.service';
import { ResultAnimeComponent } from '../result-anime/result-anime.component';

@Component({
  selector: 'app-search-anime',
  templateUrl: './search-anime.component.html',
  styleUrls: ['./search-anime.component.scss']
})
export class SearchAnimeComponent {

  searchTerm: string ='';

  constructor(private animeService :AnimeService) { }

 

  search(){   
     this.animeService.getAnimes(this.searchTerm).subscribe( result => {
       this.animeService.addResultAnime(result.data);
       this.searchTerm = '';
     });
  }




}
