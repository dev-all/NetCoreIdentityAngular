import { EventEmitter, Component, Input, OnInit, Output } from '@angular/core';

import { SOLID_BUTTON_TYPE_ENUM } from './solid-button-type.enum';

@Component({
  selector: 'app-solid-button',
  templateUrl: './solid-button.component.html',
  styleUrls: ['./solid-button.component.scss']
})
export class SolidButtonComponent  {

@Input() title: string = '' ;
@Input() type : SOLID_BUTTON_TYPE_ENUM = SOLID_BUTTON_TYPE_ENUM.PRIMARY;
@Input() url : string= '';


//EventEmmiter debe ser de @angular/core
// output indicando q campio el objeto
@Output() action = new EventEmitter(); 
  $btnTypes: any;




}
