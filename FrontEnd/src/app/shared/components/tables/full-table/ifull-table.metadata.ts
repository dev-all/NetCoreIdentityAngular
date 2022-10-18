import { BehaviorSubject } from "rxjs";

export interface IFullTable{
  initialData: {data: any[]; total: number;};
  
  subjecTable: BehaviorSubject<{data: any[], total:number;}>;
  /**
   * get all data of table
   */
  getData:() => void;
  
  getCurrentItems:any[];
  
}