import { Component, OnInit } from '@angular/core';
import { TblUsrService } from '@data/services/pages/user/tbl-usr.service';
import { SOLID_BUTTON_TYPE_ENUM } from '@share/components/buttons/solid-button/solid-button-type.enum';

@Component({
  selector: 'app-ejemplo-four',
  templateUrl: './ejemplo-four.component.html',
  styleUrls: ['./ejemplo-four.component.scss'],
  //providers:[TblUsrService]  // c/ vez q se crea el componente se obtienen los datos iniciales del sevicio dependera de la logica 
})
export class EjemploFourComponent  {

  public $btnTypes= SOLID_BUTTON_TYPE_ENUM;

  constructor( public serviceTable:TblUsrService) { }



}
