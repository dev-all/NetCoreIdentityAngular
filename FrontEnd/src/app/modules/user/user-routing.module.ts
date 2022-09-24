import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserListComponent } from './user-list/user-list.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '@core/guard/auth.guard';
import { INTERNAL_PATHS } from '@data/constants/routes';

const routes: Routes = [  
      {
        path: INTERNAL_PATHS.PAGE_USER_LIST,
        component: UserListComponent,
        canActivate :[AuthGuard]        
      },
      {
        path: INTERNAL_PATHS.PAGE_USER_DETAIL,
        component: UserDetailComponent,
        canActivate :[AuthGuard] 
      }
      ,
      {
        path: INTERNAL_PATHS.PAGE_USER_PROFILE,
        component: UserProfileComponent,
        canActivate :[AuthGuard] 
      }        
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class UserRoutingModule {}