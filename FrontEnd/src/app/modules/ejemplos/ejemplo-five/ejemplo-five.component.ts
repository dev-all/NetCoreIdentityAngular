import { Component, OnInit } from '@angular/core';
import { TblUsrService } from '@data/services/pages/user/tbl-usr.service';

@Component({
  selector: 'app-ejemplo-five',
  templateUrl: './ejemplo-five.component.html',
  styleUrls: ['./ejemplo-five.component.scss'],
  providers:[TblUsrService]  // c/ vez q se crea el componente se obtienen los datos iniciales del sevicio dependera de la logica 
})
export class EjemploFiveComponent implements OnInit{


  constructor( public serviceTable:TblUsrService) { }

  ngOnInit(): void {
    this.serviceTable.getData(); 
  }



}
