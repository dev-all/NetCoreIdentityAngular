import { Component, OnInit } from '@angular/core';
import { ComunicacionService } from '@share/services/comunicacion/comunicacion.service';

@Component({
  selector: 'app-nietob',
  templateUrl: './nietob.component.html',
  styleUrls: ['./nietob.component.scss']
})
export class NietobComponent implements OnInit {
mensaje!:string;
  constructor(
    private _servicioComunicacion:ComunicacionService
  ) { }

  ngOnInit(): void {
    this._servicioComunicacion.enviarMensajeObservable.subscribe((response: string) =>{
      this.mensaje = response;
    })
  }
  cambiarTexto(texto:string){
    this._servicioComunicacion.enviarMensaje(texto);
  }
}
