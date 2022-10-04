import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-ft-thead, [app-ft-thead]',
  templateUrl: './ft-thead.component.html',
  styleUrls: ['./ft-thead.component.scss']
})
export class FtTheadComponent  {
  @Input() data: Array<string>=[];
  constructor() { }


}
