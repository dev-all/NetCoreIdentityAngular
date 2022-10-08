import { IFullTable } from '../ifull-table.metadata';

export class FullTableService {

  constructor(
    private service: IFullTable
    ) { }

  initData(){
    if(this.service.getCurrentItems.length <=0){
      this.getData();
    }
  } 

  getData() {
    this.service.getData();
  }

  get getMessageFooter(): string{
    return this.service.getCurrentItems.length <= 0 ? 'No hay registros' : `${ this.service.getCurrentItems.length } registros`;
  }
}
