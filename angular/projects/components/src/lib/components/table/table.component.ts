import { Component, ContentChild, EventEmitter, Input, Output, TemplateRef } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';

@Component({
  selector: 'dignite-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.scss']
})
export class TableComponent {

  @Input()
  set data(value: any[]) {
    this.rows = value;
  }
  @Input() set pages(value : string) {
    this. page= value;
  }
  @Input() set loading(value : boolean) {
    this.loadingIndicator= value;
  }
  @Input() columns:any[]=[]
  @Output() pageChange=  new EventEmitter()
  
  @ContentChild('digniteTable', ) digniteTable?: TemplateRef<any>;


  /**表格数据 */
  rows = [];
  /**表格加载 */
  loadingIndicator = true;
  // sortable: false
  /**列数据 */
  // columns = [];
  /**列类型 */
  ColumnMode = ColumnMode;
  /**分页数据 */
  page: any = {
    skipCount: 0,
    maxResultCount: 15,
    total: 0
  }

  setPage(event) {
    this.page.skipCount = event.offset
    this.pageChange.emit(this.page)
  }
}
