import { BehaviorSubject } from "rxjs";
import { IFullTable } from "../ifull-table.metadata";

export class FullTableClass implements IFullTable{
  
  initialData ={ data: [], total: 0};

  public subjecTable!: BehaviorSubject<{ data: any[]; total: number; }>;

  getData() : void {};

  get getCurrentItems() : any[] {
    return this.subjecTable.value.data;
  }
  
}
