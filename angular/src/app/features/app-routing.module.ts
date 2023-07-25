import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';

@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'users', loadChildren: 
                    () => import('../users/features/user-shell/user-shell.module')
                    .then((m) => m.UserShellModule),
                    canActivate: [AppRouteGuard]}
                ]
            },
            {
                path: 'configurations',
                loadChildren: () =>
                  import(
                    '../configurations/features/configuration-shell/configurations.module'
                  ).then((m) => m.ConfigurationsModule),
                //data: { permission: 'Pages.Configurations' },
                canActivate: [AppRouteGuard],
              },
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
