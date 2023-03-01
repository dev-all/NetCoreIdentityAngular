import { Component, OnDestroy, OnInit } from '@angular/core';
import { DataService } from '@share/services/data/data.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-hijo',
  templateUrl: './hijo.component.html',
  styleUrls: ['./hijo.component.scss']
})
export class HijoComponent  {
  mensaje: string = 'Mensaje';
  nombreSuscription!: Subscription;

  constructor(
    public dataService: DataService) { }

  // ngOnInit() {implements OnInit,OnDestroy
  //   // this.nombreSuscription= this.dataService.nombre$.subscribe( texto => {
  //   //    this.mensaje = texto;
  //   //    console.log('hijo:', texto);
  //   //    });

  //    //  this.dataService.nombre$.emit('hijo!');
  //  }

  //  ngOnDestroy(){
  //   //  console.log('ngOnDestroy');
  //   //  this.nombreSuscription.unsubscribe();
  //  }


}
