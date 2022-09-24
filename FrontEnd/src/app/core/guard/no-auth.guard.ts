import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services/api/security/auth.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NoAuthGuard implements CanActivate {

  constructor(private router: Router
    ,private authService: AuthService) {

  }


  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot):  boolean {
debugger;
    const currentUser = this.authService.getUser;
    if(currentUser){
       // INTERNAL_ROUTES.PAGE_DEFAULT es una page que no necesita autenticacion
    this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
    return false;
    }
   
   
    return true;
  }


  
}
