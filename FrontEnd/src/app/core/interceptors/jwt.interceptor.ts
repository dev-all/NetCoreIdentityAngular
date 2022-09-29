import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { API_ROUTES } from "@data/constants/routes";
import { AuthService } from "@data/services/api/security/auth.service";
import { catchError, Observable, throwError } from "rxjs";

@Injectable()
export class JwtInterceptor implements HttpInterceptor{

  constructor(private routes: Router
              ,private authServices: AuthService){ }

  intercept(req: HttpRequest<any>
          , next: HttpHandler): Observable<HttpEvent<any>> {

            debugger;
      const currentUser = this.authServices.getUser;
      const isAuthenticated = currentUser && currentUser.token;

      //logeado y no is login
//      if(isAuthenticated || req.url !== API_ROUTES.AUTH.SIGNIN ) {
  if(isAuthenticated) {
          req = req.clone({
            setHeaders:{
              Authorization : `Bearer ${currentUser.token}`
            }
          })
      }

      return next.handle(req);
  }

}
