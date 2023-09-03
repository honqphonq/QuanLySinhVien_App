import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfigurationsPage } from '../configuration-page/configurations.page';
import { SharedModule } from '@shared/shared.module';
import { ConfigurationsRoutingModule } from '../configuration-shell/configurations-routing.module';
import {ConfigurationsSubjectComponent} from '../configuration-subject/configurations-subject.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import {ConfigurationsPageLayoutComponent} from '../../ui/configurations-page-layout/configurations-page-layout.component';
import {ConfigurationsSidebarComponent} from '../../ui/configurations-sidebar/configurations-sidebar.component';
import {SubjectsGridComponent} from '../../ui/subjects-grid/subjects-grid.component';
import { AgGridModule } from 'ag-grid-angular';
import { NzModalModule } from 'ng-zorro-antd/modal';

@NgModule({
  declarations: [
    ConfigurationsPage,
    ConfigurationsSubjectComponent,
    ConfigurationsPageLayoutComponent,
    ConfigurationsSidebarComponent,
    SubjectsGridComponent,
  ],
  imports: [
    ConfigurationsRoutingModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    NzLayoutModule,
    NzModalModule,
    AgGridModule,
  ],
})
export class ConfigurationsModule { }
