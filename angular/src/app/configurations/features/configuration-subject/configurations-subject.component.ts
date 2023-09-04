import { Component, Injector } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { SubjectCreateRequest, SubjectEditDto, SubjectGetAllResponse, SubjectServiceProxy } from '@shared/service-proxies/service-proxies';
import { Observable, finalize } from 'rxjs';
import { NzModalService } from 'ng-zorro-antd/modal';
import { FormControl } from '@angular/forms';
import { SubjectEditModalComponent, SubjectFormData } from '@app/configurations/ui/subject-edit-modal/subject-edit-modal.component';

@Component({
  selector: 'app-configurations-subject',
  templateUrl: './configurations-subject.component.html',
})
export class ConfigurationsSubjectComponent extends AppComponentBase {
  subjectServices$: Observable<SubjectGetAllResponse[]>;
  saving = false;
  searchInput = new FormControl('');

  constructor(
    injector: Injector, 
    private _subjectService: SubjectServiceProxy, 
    private _nzModalService: NzModalService
  ) {
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
      nzContent: SubjectEditModalComponent,
      nzFooter: null,
    });

    modal.componentInstance.onSave.subscribe((data: SubjectFormData) => {
      const createDto = new SubjectCreateRequest({ ... data });

      this._subjectService
        .create(createDto)
        .pipe(finalize(() => modal.componentInstance.saving = false))
        .subscribe(() => {
          modal.close();
          this.refresh();
          this.notify.success('Saved Successfully');
        })
    })
  }

  edit(subject: SubjectEditDto) {
    this._subjectService.get(subject.id).subscribe(({ id, name, description}) => {
      const modal = this._nzModalService.create({
        nzTitle: 'Edit',
        nzContent: SubjectEditModalComponent,
        nzFooter: null,
      });

      modal.componentInstance.initForm({
        id,
        name,
        description
      })

      modal.componentInstance.onSave.subscribe((data: SubjectFormData) => {
        const editDto = new SubjectEditDto({ ...data });

        this._subjectService.edit(editDto).pipe(finalize(() => this.saving = false)).subscribe(() => {
          modal.close();
          this.refresh();
          this.notify.success('Saved Successfully!')
        })
      })
    })
  }

  delete(subject: SubjectEditDto) {
    this.message.confirm(
      `${subject.name}` + ' can delete',
      'Are you sure?',
      (isConfirmed) => {
        if(isConfirmed) {
          this._subjectService.delete(subject.id).subscribe(() => {
            this.refresh();
            this.notify.success('Deleted Successfully!');
          });
        }
      }
    )
  }
}