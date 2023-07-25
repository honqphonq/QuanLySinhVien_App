import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { UserListPage } from '../user-list/user-list.page';

const routes = RouterModule.forChild([
  {
    path: '',
    pathMatch: 'full',
    component: UserListPage,
    canActivate: [AppRouteGuard],
    data: { permission: 'Pages.Users' },
  },
]);

@NgModule({
  imports: [routes],
  exports: [RouterModule],
})
export class UserShellRoutingModule {}
