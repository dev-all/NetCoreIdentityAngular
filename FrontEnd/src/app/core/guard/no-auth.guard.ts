import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services/api/security/auth.service';

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

    const currentUser = this.authService.getUser;
    if(currentUser){
<<<<<<< HEAD
    //  debugger;
       // INTERNAL_ROUTES.PAGE_DEFAULT es una page que no necesita autenticacion
      this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
=======
      // debugger;
      // INTERNAL_ROUTES.PAGE_DEFAULT es una page que no necesita autenticacion
      // this.router.navigateByUrl(INTERNAL_ROUTES.PAGE_DEFAULT);
>>>>>>> 14811b8cb0a0f1e4961333a3aa9015b6afaaadf2
      return false;
    }


    return true;
  }



}
