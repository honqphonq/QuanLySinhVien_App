import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfigurationsPage } from '../configuration-page/configurations.page';
import { SharedModule } from '@shared/shared.module';
import { ConfigurationsRoutingModule } from '../configuration-shell/configurations-routing.module';
import { ConfigurationsSubjectComponent } from '../configuration-subject/configurations-subject.component';
import { NzLayoutModule } from 'ng-zorro-antd/layout';
import { ConfigurationsPageLayoutComponent } from '../../ui/configurations-page-layout/configurations-page-layout.component';
import { ConfigurationsSidebarComponent } from '../../ui/configurations-sidebar/configurations-sidebar.component';
import { SubjectsGridComponent } from '../../ui/subjects-grid/subjects-grid.component';
import { SubjectEditModalComponent } from '../../ui/subject-edit-modal/subject-edit-modal.component';
import { AgGridModule } from 'ag-grid-angular';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzFormModule } from 'ng-zorro-antd/form';
import { NzButtonModule } from 'ng-zorro-antd/button';
import { ValdemortModule } from 'ngx-valdemort';

@NgModule({
  declarations: [
    ConfigurationsPage,
    ConfigurationsSubjectComponent,
    ConfigurationsPageLayoutComponent,
    ConfigurationsSidebarComponent,
    SubjectsGridComponent,
    SubjectEditModalComponent,
  ],
  imports: [
    ConfigurationsRoutingModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    NzLayoutModule,
    NzModalModule,
    AgGridModule,
    NzFormModule,
    NzButtonModule,
    ValdemortModule,
  ],
})
export class ConfigurationsModule { }
