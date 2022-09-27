import { Injectable } from '@angular/core';
import {
  CanActivate,
  RouterStateSnapshot,
  ActivatedRouteSnapshot,
} from '@angular/router';
import { Router } from '@angular/router';
import { INTERNAL_ROUTES } from '@data/constants/routes';
import { AuthService } from '@data/services/api/security/auth.service';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(private router: Router, private authService: AuthService) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ): boolean {
   
    const currentUser = this.authService.getUser;
    if (currentUser) {
      return true;
    }

    // not logged in so redirect to login page with the return url
    //    this.router.navigate([INTERNAL_ROUTES.AUTH_LOGIN], { queryParams: { returnUrl: state.url } });
    this.router.navigate([INTERNAL_ROUTES.AUTH_LOGIN]);
    return false;
  }

  // canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
  //   if (localStorage.getItem('isLoggedin')) {
  //     // logged in so return true
  //     return true;
  //   }

  //   // not logged in so redirect to login page with the return url
  //   this.router.navigate(['/auth/login'], { queryParams: { returnUrl: state.url } });
  //   return false;
  // }
}
