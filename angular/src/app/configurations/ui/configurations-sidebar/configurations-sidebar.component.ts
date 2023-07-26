import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';

export interface ConfigurationsSidebarItem {
  route: string;
  label: string;
}
@Component({
  selector: 'app-configurations-sidebar',
  templateUrl: './configurations-sidebar.component.html',
})
export class ConfigurationsSidebarComponent extends AppComponentBase {
  constructor(injector: Injector) {
    super(injector)
  }
  links: ConfigurationsSidebarItem[] = [
    { route: 'subjects', label: this.l('Subjects') },
  ];
}
