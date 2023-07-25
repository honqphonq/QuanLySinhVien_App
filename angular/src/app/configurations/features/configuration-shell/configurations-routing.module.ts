import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { ConfigurationsPage } from '../configuration-page/configurations.page'
import { ConfigurationsSubjectComponent } from '../configuration-subject/configurations-subject.component';

const routes = RouterModule.forChild([
  {
    path: '',
    component: ConfigurationsPage,
    canActivate: [AppRouteGuard],
    children: [
      {
        path: '', redirectTo: 'subjects', pathMatch: 'full'
      },
      {
        path: 'subjects',
        component: ConfigurationsSubjectComponent
      }
    ]
  },
]);

@NgModule({
  imports: [routes],
  exports: [RouterModule],
})
export class ConfigurationsRoutingModule {}
