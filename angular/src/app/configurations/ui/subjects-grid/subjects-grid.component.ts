import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SubjectEditDto, SubjectGetAllResponse } from '@shared/service-proxies/service-proxies';
import { ActionRendererComponent } from '@shared/components/ag-grid/action-renderer/action-renderer.component';
import { GridOptions, GridSizeChangedEvent } from 'ag-grid-community';

@Component({
  selector: 'app-subjects-grid',
  templateUrl: './subjects-grid.component.html'
})

export class SubjectsGridComponent {
  @Input() set items(value: SubjectGetAllResponse[]) {
    this.gridOptions.api?.setRowData(value);
  }
  @Output() onDelete = new EventEmitter<SubjectEditDto>();
  @Output() onEdit = new EventEmitter<SubjectEditDto>();

  gridOptions: GridOptions = {
    defaultColDef: {
      editable: true,
      enableRowGroup: true,
      enablePivot: true,
      enableValue: true,
      sortable: true,
      resizable: true,
      filter: false,
      flex: 1,
    },
    columnDefs: [
      {
        field: 'name',
        headerName: 'Name',
      },
      {
        field: 'description',
        headerName: 'Description',
      },
      {
        field: 'id',
        headerName: '',
        filter: false,
        sortable: false,
        headerComponentParams: { template: '<i class="fa fa-cog"></i>' },
        cellRenderer: ActionRendererComponent,
        cellRendererParams: {
          onDelete: this.delete.bind(this),
          onEdit: this.edit.bind(this),
        },
      }
    ],
    suppressCellFocus: true,
    paginationPageSize: 10,
    domLayout: 'autoHeight',
    pagination: true,
    onFirstDataRendered: this.onFirstDataRendered,
    onGridReady: this.onFirstDataRendered,
  }

  onFirstDataRendered(params) {
    params.api.sizeColumnsToFit();
  }

  onGridSizeChanged(params: GridSizeChangedEvent) {
    var gridWidth = document.getElementById('grid-wrapper')!.offsetWidth;
    var columnsToShow = [];
    var columnsToHide = [];
    var totalColsWidth = 0;
    var allColumns = params.columnApi.getColumns();

    if (allColumns && allColumns.length > 0) {
      for (var i = 0; i < allColumns.length; i++) {
        var column = allColumns[i];
        totalColsWidth += column.getMinWidth() || 0;
        if (totalColsWidth > gridWidth) {
          columnsToHide.push(column.getColId());
        } else {
          columnsToShow.push(column.getColId());
        }
      }
    }

    params.columnApi.setColumnsVisible(columnsToShow, true);
    params.columnApi.setColumnsVisible(columnsToHide, false);
    params.api.sizeColumnsToFit();
  }

  delete(subject: SubjectEditDto) {
    this.onDelete.emit(subject);
  }

  edit(subject: SubjectEditDto) {
    this.onEdit.emit(subject);
  }
}