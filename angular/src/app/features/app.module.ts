import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientJsonpModule } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { NgxPaginationModule } from 'ngx-pagination';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ServiceProxyModule } from '@shared/service-proxies/service-proxy.module';
import { SharedModule } from '@shared/shared.module';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { NzIconModule } from 'ng-zorro-antd/icon';
import { NzMenuModule } from 'ng-zorro-antd/menu';

// layout
import { HeaderComponent } from '../layout/header/header.page';
import { HeaderLanguageMenuComponent } from '../layout/header/header-language-menu.component';
import { HeaderUserMenuComponent } from '../layout/header/header-user-menu.component';
import { SidebarComponent } from '../layout/sidebar/sidebar.page';
import { SidebarMenuComponent } from '../layout/sidebar/sidebar-menu.component';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        HeaderLanguageMenuComponent,
        HeaderUserMenuComponent,
        SidebarComponent,
        SidebarMenuComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule,
        HttpClientJsonpModule,
        ModalModule.forChild(),
        BsDropdownModule,
        CollapseModule,
        TabsModule,
        AppRoutingModule,
        ServiceProxyModule,
        SharedModule,
        NgxPaginationModule,
        NzLayoutModule,
        NzIconModule,
        NzMenuModule,
    ],
    providers: []
})
export class AppModule {}
