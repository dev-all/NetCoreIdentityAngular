import { Injectable } from '@angular/core';
import { IApiUser } from '@data/interfaces';
import { UserService } from '@data/services/api/user.service';
import { FullTableClass } from '@share/components/tables/full-table/schema/full-table-class';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TblUsrService extends FullTableClass  {

  

  constructor(
    private userService:UserService
  ) { 
    super();  // heredamos todo de la clase FullTableClass

    this.subjecTable = new BehaviorSubject<{
      data: IApiUser[];
      total: number;
    }>(this.initialData);
  }

  override getData(): void {
    this.userService.getAllUsers().subscribe(r => {
      console.log('call service tblUsrService  ')
      this.subjecTable.next({data: r, total: r.length})
    })
  }
/// override permite sobreescribir el metodo diciendo q tipo de obj va a retornar
  override get getCurrentItems(): IApiUser[] {
    return this.subjecTable.value.data;
  }

}
