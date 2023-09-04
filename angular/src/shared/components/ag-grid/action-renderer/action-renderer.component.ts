import { Component } from '@angular/core';
import { ICellRendererAngularComp } from 'ag-grid-angular';
import { ICellRendererParams } from 'ag-grid-community';

@Component({
  selector: 'app-action-renderer',
  templateUrl: './action-renderer.component.html',
  styleUrls: ['./action-renderer.component.less'],
})
export class ActionRendererComponent implements ICellRendererAngularComp {
  params!: IActionCellRendererParams;

  // gets called once before the renderer is used
  agInit(params: IActionCellRendererParams): void {
    this.params = params;
  }

  // gets called whenever the cell refreshes
  refresh(params: IActionCellRendererParams): boolean {
    // set value into cell again
    this.params = params;
    return true;
  }

  edit(e: PointerEvent) {
    e.stopPropagation();
    this.params.onEdit(this.params.data);
  }

  delete(e: PointerEvent) {
    e.stopPropagation();
    this.params.onDelete(this.params.data);
  }

  print(e: PointerEvent) {
    e.stopPropagation();

    this.params.onPrint(this.params.data);
  }

  getStatus() {
    return this.params.data.status;
  }
}

export interface IActionCellRendererParams extends ICellRendererParams {
  onEdit: (rowData: any) => {};
  onDelete: (rowData: any) => {};
  onPrint: (rowData: any) => {};
}
