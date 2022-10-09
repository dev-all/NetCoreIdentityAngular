import { Component, Input, OnInit } from '@angular/core';
import { IApiUser } from '@data/interfaces';

@Component({
  selector: 'app-card-basic',
  templateUrl: './card-basic.component.html',
  styleUrls: ['./card-basic.component.scss']
})
export class CardBasicComponent {
  @Input() data!: IApiUser;
  constructor() { }



}
