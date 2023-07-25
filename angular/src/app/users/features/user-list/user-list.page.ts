import { Component} from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
  templateUrl: './user-list.page.html',
  animations: [appModuleAnimation()]
})
export class UserListPage {
  
}
