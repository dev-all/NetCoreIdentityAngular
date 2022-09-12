import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-hookonchange',
  templateUrl: './hookonchange.component.html',
  styleUrls: ['./hookonchange.component.scss']
})
export class HookonchangeComponent implements OnChanges  {

  @Input() pricePesos:number;
  @Input() priceDollar:number;
  @Input() priceEuro:number;

  constructor() {
    this.pricePesos = 0;
    this.priceDollar = 0;
    this.priceEuro = 0;

  }
  ngOnChanges(c: SimpleChanges): void {
   console.log('user list -> to -> hook onchange ');

    if(c['pricePesos'] && c['pricePesos'].currentValue ){
      this.pricePesos = c['pricePesos'].currentValue;
      this.priceDollar = this.pricePesos * this.getCurrentDollarFromApi();
      this.priceEuro = this.pricePesos * this.getCurrentEuroFromApi();
    }

  }

// procedimiento que se emulate la consulta a una api para optener el precio de la moneda
  getCurrentDollarFromApi(){
    return 208;
  }
  getCurrentEuroFromApi(){
    return 215;
  }
}
