import { UserRoutingModule } from './user-routing.module';
import { SharedModule } from './../../shared/shared.module';
import { NgModule } from '@angular/core';
import { UserListComponent } from './user-list/user-list.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { UserComponent } from './user.component';

@NgModule({
  declarations: [UserComponent, UserListComponent, UserDetailComponent],
  imports: [SharedModule, UserRoutingModule],
})
export class UserModule {}
