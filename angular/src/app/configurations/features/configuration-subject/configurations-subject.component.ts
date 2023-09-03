import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { SubjectGetAllResponse, SubjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { Observable } from 'rxjs';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-configurations-subject',
  templateUrl: './configurations-subject.component.html',
})
export class ConfigurationsSubjectComponent extends AppComponentBase {
  subjectServices$: Observable<SubjectGetAllResponse[]>;
  saving = false;
  searchInput = new FormControl('');

  constructor(injector: Injector, private _subjectService: SubjectServiceProxy, private _nzModalService: NzModalService) {
    super(injector);

    this.refresh()
  }

  refresh() {
    const searchTerm = this.searchInput.value;
    this.subjectServices$ = this._subjectService.getAll(searchTerm);
  }

  add() {
    const modal = this._nzModalService.create({
      nzTitle: 'Create',
    })

  }
}
