import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable, Output } from '@angular/core';
import { Router } from '@angular/router';
import { ERRORS_CONST } from '@data/constants';
import { API_ROUTES, INTERNAL_ROUTES } from '@data/constants/routes';
import { IApiUserAuthenticated } from '@data/interfaces';
//import { environment } from 'environments/environment';
import { environment } from 'environments/environment.prod';
import { BehaviorSubject, catchError, map, Observable, of, Subject } from 'rxjs';
import { Response } from '@data/interfaces/api/response';
import { LoginModel } from '@data/interfaces/api/login.model';

import { JwtHelperService} from '@auth0/angular-jwt';
import { UserModel } from '@data/schema';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

 // public url=environment.uri;

  public resp!: Response;

  public user!:IApiUserAuthenticated;

  public userSubject$! : BehaviorSubject<IApiUserAuthenticated>; //tipo especial de observable

  //usaría BehaviorSubjectpara un servicio de datos, ya que un servicio angular
  //a menudo se inicializa antes de que el componente y el sujeto de comportamiento
  //garanticen que el componente que consume el servicio reciba los últimos datos
  //actualizados, incluso si no hay nuevas actualizaciones desde la suscripción del componente a estos datos.
  //public usuario$ : Observable<IApiUserAuthenticated>;

  public userLocalStorage = 'currentUserAngular';
  helper: JwtHelperService;


  constructor(  protected http: HttpClient
              , private router: Router){
    this.userSubject$ =  this.GetItem();
    this.helper = new JwtHelperService();
  }




  // signUp(user : UserModel):Observable<UserModel>{
  //   return this.http.post<UserModel>(API_ROUTES.AUTH.SIGNUP, user)
  // }

  signUp(user : UserModel):Observable<UserModel>{

    return this.http.post<Response>(API_ROUTES.AUTH.SIGNUP, user)
    .pipe(
      map(response => {
        debugger;
        if(response.status === 200)
        {
          // this.setUserToLocalStorage(response.data);
          // this.userSubject$.next(response.data);
          this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
        }
        return response;
     }),
      catchError(e => {

        this.router.navigateByUrl(INTERNAL_ROUTES.ERROR_API);
        return of(e.message);

      })
    );
  }
  // signIn(user : UserModel):Observable<UserModel>{
  //   return this.http.post<UserModel>(API_ROUTES.AUTH.SIGNIN, user)
  // }
  signIn(user : UserModel):Observable<Response>{
    return this.http.post<Response>(API_ROUTES.AUTH.SIGNIN, user)
          .pipe(
            map(response => {

              if(response.status === 200)
              {
                this.setUserToLocalStorage(response.data);
                this.userSubject$.next(response.data);
                this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
              }
              return response;
           }),
            catchError(e => {

              this.router.navigateByUrl(INTERNAL_ROUTES.ERROR_API);
              return of(e.message);

            })
          );
  }

  sendRecoveryLink(user : UserModel):Observable<UserModel>{
    return this.http.post<UserModel>(API_ROUTES.AUTH.SENDRECOVERYLIKN, user)
  }

  public GetItem(){
    return new BehaviorSubject<IApiUserAuthenticated>(JSON.parse(localStorage.getItem(this.userLocalStorage)!));
   }

  public get getUser(): IApiUserAuthenticated{
    return this.userSubject$.value;
  }

  // public login( _loginModel: LoginModel ): Observable<Response> {

  //   return this.http.post<Response>(API_ROUTES.AUTH.SIGNIN, _loginModel)
  //     .pipe(
  //       map(r => {

  //         this.response.error = r.error;
  //         this.response.msg = r.msg;
  //         this.response.data = r.data;
  //         this.setUserToLocalStorage(r.data);
  //         this.userSubject$.next(r.data);
  //         if (!this.response.error) {
  //           this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
  //         }
  //         return this.response;
  //       }),
  //       catchError(e => {
  //         return of(this.response);
  //       })
  //     );
  // }

  private setUserToLocalStorage( user : IApiUserAuthenticated){
    localStorage.setItem(this.userLocalStorage, JSON.stringify(user));
  }

  public logout(){
    localStorage.removeItem(this.userLocalStorage);
    localStorage.removeItem('InitLoginEmail');
    this.userSubject$.next(this.user);
    this.router.navigateByUrl(INTERNAL_ROUTES.AUTH_LOGIN);
  }








}
