import { Component, OnInit } from '@angular/core';
import { SOLID_BUTTON_TYPE_ENUM } from '@share/components/buttons/solid-button/solid-button-type.enum';

@Component({
  selector: 'app-ejemplo-one',
  templateUrl: './ejemplo-one.component.html',
  styleUrls: ['./ejemplo-one.component.scss']
})
export class EjemploOneComponent  {

  public $btnTypes= SOLID_BUTTON_TYPE_ENUM;

  
  constructor() { }



}
