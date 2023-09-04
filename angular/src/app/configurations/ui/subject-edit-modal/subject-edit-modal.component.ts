import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NzModalRef } from 'ng-zorro-antd/modal';

export interface SubjectFormData {
  id: string;
  name: string | undefined;
  description: string | undefined;
}

@Component({
  selector: 'subject-edit-modal',
  templateUrl: './subject-edit-modal.component.html'
})

export class SubjectEditModalComponent {
  @Output() onSave = new EventEmitter<SubjectFormData>();
  form: FormGroup;
  saving = false;

  constructor(private fb: FormBuilder, public modalRef: NzModalRef) {
    this.form = fb.group({
      id: [],
      name: ['', [Validators.required, Validators.maxLength(255)]],
      description: ['', [Validators.maxLength(255)]],
    })
  }

  initForm({ id, name, description } : SubjectFormData) {
    this.form.setValue({
      id,
      name,
      description
    })
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    this.saving = true;

    this.onSave.emit({ ...this.form.value } as SubjectFormData);
  }
}