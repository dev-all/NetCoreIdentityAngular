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
       debugger;
          console.log(ex)
          if([400,401,403,404,409].indexOf(ex.status) !== -1 ){
            this.routes.navigateByUrl('/error/'+ ex.status);
          }else{
              this.routes.navigateByUrl('/error');
          }
          //1 Respuestas informativas (100–199),
          //2 Respuestas satisfactorias (200–299),
          //3 Redirecciones (300–399),
          //4 Errores de los clientes (400–499),
          //5 y errores de los servidores (500–599).
          //   debugger;
          //   if(response.status === 200)
          //     {
          //       this.serviceAuth.setUserToLocalStorage(response.data);
          //       this.serviceAuth.userSubject$.next(response.data);
          //       this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
          //     }
          //   if(response.status === 201)
          //     {
          //       this.isLoading=false;
          //       this.errorMessage= response.message || "" ;
          //       return;
          //     }
          //   }
          // );
         return throwError(() => new Error(ex.status));
      })
    );
  }

}
