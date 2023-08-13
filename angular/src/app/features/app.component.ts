import { Component, Injector, OnInit, Renderer2 } from "@angular/core";
import { AppComponentBase } from "@shared/app-component-base";

@Component({
  templateUrl: "./app.component.html",
})
export class AppComponent extends AppComponentBase {
  sidebarExpanded: boolean;

  constructor(injector: Injector) {
    super(injector);
  }
}
