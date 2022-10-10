import { Component, ElementRef, Input,  Renderer2,  ViewChild } from '@angular/core';

@Component({
  selector: 'app-mmodal',
  templateUrl: './mmodal.component.html',
  styleUrls: ['./mmodal.component.scss']
})
export class MmodalComponent  {

  @Input() title = '';
  @ViewChild('modalBack') modalBack!: ElementRef;
  public show = false;

  constructor( private renderer: Renderer2  ) {
    this.renderer.listen('window','click',(e : Event) =>{
      //console.log('modal constructor');
      if(this.modalBack && e.target === this.modalBack.nativeElement){
        this.show =false;
      }
     });
   }

   showModal(){
    this.show = true;
   }

   hideModal(){
    this.show = false;
   }
}
