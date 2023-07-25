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
// layout
import { HeaderComponent } from '../layout/header.component';
import { HeaderLanguageMenuComponent } from '../layout/header-language-menu.component';
import { HeaderUserMenuComponent } from '../layout/header-user-menu.component';
import { SidebarComponent } from '../layout/sidebar.component';
import { SidebarLogoComponent } from '../layout/sidebar-logo.component';
import { SidebarUserPanelComponent } from '../layout/sidebar-user-panel.component';
import { SidebarMenuComponent } from '../layout/sidebar-menu.component';

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        HeaderLanguageMenuComponent,
        HeaderUserMenuComponent,
        SidebarComponent,
        SidebarLogoComponent,
        SidebarUserPanelComponent,
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
    ],
    providers: []
})
export class AppModule {}
