import { Component, OnInit } from '@angular/core';
import { ComunicacionService } from '@share/services/comunicacion/comunicacion.service';

@Component({
  selector: 'app-padre',
  templateUrl: './padre.component.html',
  styleUrls: ['./padre.component.scss']
})
export class PadreComponent   {

  constructor(
    public _servicioComunicacion:ComunicacionService
  ) { }


}
