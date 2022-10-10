import { Component, OnDestroy, OnInit } from '@angular/core';
import { AuthService } from '@data/services/api/security/auth.service';
import { SOLID_BUTTON_TYPE_ENUM } from '@share/components/buttons/solid-button/solid-button-type.enum';

@Component({
  selector: 'app-ejemplo-six',
  templateUrl: './ejemplo-six.component.html',
  styleUrls: ['./ejemplo-six.component.scss']
})
export class EjemploSixComponent implements OnDestroy{

  public $btnTypes= SOLID_BUTTON_TYPE_ENUM;
  title = 'Lista de usuarios';
  constructor( public authServices: AuthService) { }
 

  changeTitle(){
    this.title= 'Nuevo titulo'
  }

  ngOnDestroy(): void {
   this.authServices.clearServices();
  }
 
}
