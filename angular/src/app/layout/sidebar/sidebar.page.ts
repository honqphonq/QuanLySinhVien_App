import {
  ChangeDetectionStrategy,
  Component,
  EventEmitter,
  Injector,
  Input,
  Output,
} from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { MenuItem } from '@shared/layout/menu-item';

@Component({
  // tslint:disable-next-line:component-selector
  selector: 'sidebar',
  templateUrl: './sidebar.page.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SidebarComponent extends AppComponentBase {
  sidebarExpanded: boolean;
  @Input() showLogo: boolean = true;
  @Input() menuItems: MenuItem[];
  @Input() isCollapsed: boolean = true;
  @Output() collapsed = new EventEmitter<boolean>();
  @Output() toggleLogo = new EventEmitter<boolean>();

  constructor(injector: Injector) {
    super(injector);
  }
}
