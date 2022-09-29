import { NgModule } from '@angular/core';
import {  HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard } from './guard/auth.guard';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { JwtInterceptor } from './interceptors/jwt.interceptor';



@NgModule({

  imports: [
    HttpClientModule
  ],
  providers: [
    AuthGuard,
    {
      provide:HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi:true
    },
    {
      provide:HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi:true
    }
  ],
})
export class CoreModule { }
