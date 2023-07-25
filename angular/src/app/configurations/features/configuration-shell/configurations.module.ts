import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { ConfigurationsPage } from '../configuration-page/configurations.page'
import { SharedModule } from '@shared/shared.module';
import { ConfigurationsRoutingModule } from '../configuration-shell/configurations-routing.module'
import {ConfigurationsSubjectComponent} from '../configuration-subject/configurations-subject.component'

@NgModule({
  declarations: [
    ConfigurationsPage,
    ConfigurationsSubjectComponent,
  ],
  imports: [
    ConfigurationsRoutingModule,
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
  ],
})
export class ConfigurationsModule { }
