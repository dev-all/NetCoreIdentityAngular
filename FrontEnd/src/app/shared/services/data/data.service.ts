import { EventEmitter, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  //usamos $ para indicar que es un observable
  // es importante decir que va a tipo de dato va a emitir <string>
  // este servicio lo cree para test de EventEmitter
  //
  nombre$ = new EventEmitter<string>();
  constructor() { }
}
