import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ComunicacionService {

  mensaje!: string;
//permite el envio de msj a multiples observadores , varios componentes se subscriben de este Subject
  private enviarMensajeSubject = new Subject<string>();
//  variable auxiliar nos permite simplificar  la sintaxis para q los componentes se puedan subscribir al subject
  enviarMensajeObservable = this.enviarMensajeSubject.asObservable();

  constructor() { }

  enviarMensaje(mensaje:string){
    this.mensaje = mensaje;
    this.enviarMensajeSubject.next(mensaje);
  }

}
