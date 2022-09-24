import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { NoAuthGuard } from "@core/guard/no-auth.guard";
import { INTERNAL_PATHS } from "@data/constants/routes/internal.routes";
import { LoginPassComponent } from "./login-pass/login-pass.component";
import { LoginComponent } from "./login/login.component";
import { SignUpComponent } from "./sign-up/sign-up.component";


const routes: Routes = [   

        { 
          path: INTERNAL_PATHS.AUTH_LOGIN,
          component: LoginComponent,
          canActivate:[NoAuthGuard]
        },
        {
          path: INTERNAL_PATHS.AUTH_PASS,
          component: LoginPassComponent,
          canActivate:[NoAuthGuard]
        },
        {
          path: INTERNAL_PATHS.AUTH_SIGNUP,
          component: SignUpComponent,
          canActivate:[NoAuthGuard]
        }          
 
]
  
  @NgModule({    
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
  })
  export class AuthRoutingModule { }
  