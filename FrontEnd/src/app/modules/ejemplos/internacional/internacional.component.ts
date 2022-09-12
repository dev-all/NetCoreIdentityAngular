import { Component, DoCheck, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-internacional',
  templateUrl: './internacional.component.html',
  styleUrls: ['./internacional.component.scss']
})
export class InternacionalComponent implements OnInit {

  title = 'Your Receipt';
  constructor( private titleService: Title) {
    this.titleService.setTitle($localize `${this.title}`);
   }

  ngOnInit(): void {
  }

}
