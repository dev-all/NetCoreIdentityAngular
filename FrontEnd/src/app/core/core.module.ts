import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthGuard } from './guard/auth.guard';
import { ErrorInterceptor } from './interceptors/error.interceptor';



@NgModule({

  imports: [
    HttpClientModule
  ],
  providers: [
    AuthGuard,
    {provide:HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
  multi:true}
  ],
})
export class CoreModule { }
