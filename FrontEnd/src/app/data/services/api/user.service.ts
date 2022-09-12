import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Respuesta } from '@data/interfaces/respuesta.model';
import { Apiclass } from '@data/schema/apiclass.class';
import { ICardUser } from '@share/components/cards/card-user/icard-user.metadata';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs';
import { catchError, delay, map } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class UserService  {

  public url=environment.uri;

  private title:string;
  constructor( protected http: HttpClient
    ){
      this.title ='Forms Users init';
    }

    setTitle(t: string){
      this.title = t;
    }
    getTitle():string{
      return this.title;
    }
    clearTitle(){
      this.title ='Forms Users';
    }

  /**
   * get user de apijson local
   */
   getAllUser(): Observable<ICardUser[]> {

   return this.http.get<ICardUser[]>(this.url + 'users');

   }




}
