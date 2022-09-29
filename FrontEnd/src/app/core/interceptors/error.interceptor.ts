import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { catchError, Observable, throwError } from "rxjs";

@Injectable()
export class ErrorInterceptor implements HttpInterceptor{

  constructor(private routes: Router){ }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((ex) => {
          console.log(ex)
          if([401,403,404].indexOf(ex.status) !== -1 ){
            this.routes.navigateByUrl('/'+ ex.status);
          }
          return throwError(ex);
      })
    );
  }

}
