import { Component, OnInit } from '@angular/core';
import { DataService } from '@share/services/data/data.service';

@Component({
  selector: 'app-blank',
  templateUrl: './blank.component.html',
  styleUrls: ['./blank.component.scss']
})
export class BlankComponent {

  constructor(private dataService: DataService) { }


cambiarNombre(){
 this.dataService.nombre$.emit('Leonardo');
}

}
