import { Component, Input, OnInit } from '@angular/core';
import { IFullTable } from './ifull-table.metadata';
import { FullTableService } from './services/full-table.service';

@Component({
  selector: 'app-full-table',
  templateUrl: './full-table.component.html',
  styleUrls: ['./full-table.component.scss']
})
export class FullTableComponent implements OnInit {
  // @Input() data: { head: Array<string>, body: Array<Array<string>>} = {head:[], body:[]};
  @Input() service!: IFullTable;
  public tableServices!: FullTableService;
  constructor() { 
   
  }
  ngOnInit(): void {
     this.tableServices = new FullTableService(this.service)
     this.tableServices.initData();
  }
}
