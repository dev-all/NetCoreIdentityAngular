import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-ejemplo-three',
  templateUrl: './ejemplo-three.component.html',
  styleUrls: ['./ejemplo-three.component.scss']
})
export class EjemploThreeComponent  {

  // public data = {
  //   head: ['Nombre', 'Apellido', 'Edad', 'Puesto'],
  //   body:[
  //     ['Jose', 'fina', '30', 'aguatero'],
  //     ['Josefa', 'lina', '23', 'aguatero'],
  //     ['Jose', 'fina', '25', 'aguatero'],
  //     ['Jose', 'Pipo', '67', 'aguatero']
  //   ]
  // }

  public users : Array<{name:string,lastname:string,age:number,position:string}> =
    [
      {
        name:'leon',
        lastname:'lopez', 
        age:31,
        position:'devOne'
      },
      {
        name:'lili',
        lastname:'lopez', 
        age:31,
        position:'devOne'
      },
      {
        name:'tito',
        lastname:'lopez', 
        age:31,
        position:'devOne'
      }
    ]
  

  constructor() { }

}
