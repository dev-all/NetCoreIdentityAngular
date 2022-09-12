import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ERRORS_CONST } from '@data/constants';
import { API_ROUTES, INTERNAL_ROUTES } from '@data/constants/routes';
import { IApiUserAuthenticated } from '@data/interfaces';
import { environment } from 'environments/environment';
import { BehaviorSubject, catchError, map, Observable, of, Subject } from 'rxjs';
import { Response } from '@data/interfaces/api/response';
import { LoginModel } from '@data/interfaces/api/login.model';


@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public url=environment.uri;

  public response!: Response;

  public user!:IApiUserAuthenticated;

  public userSubject$! : BehaviorSubject<IApiUserAuthenticated>; //tipo especial de observable

  //usaría BehaviorSubjectpara un servicio de datos, ya que un servicio angular a menudo se inicializa antes de que el componente y el sujeto de comportamiento garanticen que el componente que consume el servicio reciba los últimos datos actualizados, incluso si no hay nuevas actualizaciones desde la suscripción del componente a estos datos.
  //public usuario$ : Observable<IApiUserAuthenticated>;

  public userLocalStorage = 'currentUserAngular';

  public emaillogin: string = '';


  constructor(  protected http: HttpClient
              , private router: Router){

    this.userSubject$ =   this.GetItem();
  }


  public GetItem(){
  //   return new BehaviorSubject(JSON.parse(localStorage.getItem(this.userLocalStorage) || ''));
      return new BehaviorSubject<IApiUserAuthenticated>(JSON.parse(localStorage.getItem(this.userLocalStorage) || "[]"));
   }

  public get getUser(): IApiUserAuthenticated{
    return this.userSubject$.value;
  }

  public login( _loginModel: LoginModel ): Observable<Response> {

    return this.http.post<Response>(API_ROUTES.AUTH.LOGIN, _loginModel)
      .pipe(
        map(r => {

          this.response.error = r.error;
          this.response.msg = r.msg;
          this.response.data = r.data;

          this.setUserToLocalStorage(r.data);

          this.userSubject$.next(r.data);

          if (!this.response.error) {
            this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
          }
          return this.response;
        }),
        catchError(e => {
          return of(this.response);
        })
      );
  }

  private setUserToLocalStorage( user : IApiUserAuthenticated){
    localStorage.setItem(this.userLocalStorage, JSON.stringify(user));
  }

  public logout(){
    localStorage.removeItem(this.userLocalStorage);

    this.userSubject$.next(this.user);

    this.router.navigateByUrl(INTERNAL_ROUTES.AUTH_LOGIN);
  }








}
