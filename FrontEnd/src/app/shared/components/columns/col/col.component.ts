import { Component, HostBinding, Input, OnInit } from '@angular/core';
import { IClm } from './icol.metadata';

@Component({
  selector: 'app-col',
  templateUrl: './col.component.html',
  styleUrls: ['./col.component.scss']
})
export class ColComponent implements OnInit{

  @Input() sizes: IClm = { xs : 12 } ;
  @Input() classes:string ="";
  @HostBinding('class') class = '';
  
  constructor() { }
  ngOnInit(): void {
    this.class = this.getSizes(this.sizes )
  }


  getSizes(sizes:IClm): string {
    let fclass = this.classes;
    for(const k in sizes ){
      
      if(Object.prototype.hasOwnProperty.call(sizes,k)){
        
        let s = sizes[k as keyof typeof sizes];
        fclass += ` col-${k}-${s}`;
      }
    }
    return fclass;
  }
  



}
