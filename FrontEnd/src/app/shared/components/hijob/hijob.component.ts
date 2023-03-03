import { Component, OnInit } from '@angular/core';
import { ComunicacionService } from '@share/services/comunicacion/comunicacion.service';

@Component({
  selector: 'app-hijob',
  templateUrl: './hijob.component.html',
  styleUrls: ['./hijob.component.scss']
})
export class HijobComponent   {

  mensaje!:string;
  constructor(public _comunicacionService:ComunicacionService) { }

 recibirCambios(){
  this.mensaje=this._comunicacionService.mensaje
 }

}
