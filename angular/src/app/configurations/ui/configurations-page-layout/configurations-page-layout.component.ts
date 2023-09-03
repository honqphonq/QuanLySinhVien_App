import { Component, Input } from '@angular/core';
@Component({
  selector: 'app-configurations-page-layout',
  templateUrl: './configurations-page-layout.component.html',
})
export class ConfigurationsPageLayoutComponent {
  @Input() heading = 'Page Heading';
}
