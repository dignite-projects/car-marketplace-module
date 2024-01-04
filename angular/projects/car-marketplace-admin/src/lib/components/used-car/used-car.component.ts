import { Component, TemplateRef, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { Confirmation, ConfirmationService } from '@abp/ng.theme.shared';
import { usedCarStatusOptions } from '../../proxy/used-cars/used-car-status.enum';
import { UsedCarService } from '../../proxy/admin/used-cars';


@Component({
  selector: 'lib-used-car',
  templateUrl: './used-car.component.html',
  styleUrls: ['./used-car.component.scss']
})
export class UsedCarComponent {
  constructor(
    private _UsedCarService: UsedCarService,
    private router: Router,
    private _confirmationService: ConfirmationService,
  ) { }

  /**二手车状态列表 */
  usedCarStatusList: any[any] = usedCarStatusOptions;
  /**二手车列表 */
  UsedCarList: any[] = [];
  /**查询条件 */
  search: any = {
    usedCarId: '',
    // status: '',
    // trimId: '',
  };

 
  /**表格数据 */
  rows = [];
  /**表格加载 */
  loadingIndicator = true;
  // sortable: false
  /**列数据 */
  columns = [];
  /**列类型 */
  ColumnMode = ColumnMode;
  /**分页数据 */
  page: any = {
    skipCount: 0, 
    maxResultCount: 15,
    total: 0
  }
  @ViewChild('nameCol') nameCol: TemplateRef<any>;
  @ViewChild('statusCol') statusCol: TemplateRef<any>;
  @ViewChild('creationTimeCol') creationTimeCol: TemplateRef<any>;
  @ViewChild('operateCol') operateCol: TemplateRef<any>;

  ngOnInit(): void {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    // this.getUsedCarList();
  }
  /**获取二手车列表 */
  getUsedCarList() {
    this._UsedCarService
      .getList({
        ...this.search,
        sorting: '',
        skipCount: this.page.skipCount * this.page.maxResultCount,
        maxResultCount: this.page.maxResultCount,
      })
      .subscribe(async res => {
        this.loadingIndicator = false;
        this.UsedCarList = res.items;
        this.page.total = res.totalCount;
        this.columns = [
          {
            name: '名称', prop: 'name',
            cellTemplate: this.nameCol,
            // minWidth: 200,
          },
          { name: '总里程(公里)', prop: 'totalMileage' },
          { name: '过户次数', prop: 'transfersCount' },
          { name: '价格', prop: 'price' },
          { name: '颜色', prop: 'color' },
          {
            name: '状态', prop: 'status',
            cellTemplate: this.statusCol,
            minWidth: 160,
          },
          {
            name: '创建时间', prop: 'creationTime',
            cellTemplate: this.creationTimeCol,
            minWidth: 160,
          },
          {
            name: '操作', prop: 'operate',
            cellTemplate: this.operateCol,
            minWidth: 160,
          },
        ].map(el => ({
          ...el,
          minWidth: this.getCloumnWidth(el.prop)
        }));
      });
  }
  /**获取列的最小宽度 */
  getCloumnWidth(value) {
    switch (value) {
      case 'name':
        return 300;
        break;
      case 'status':
        return 120;
        break;
      case 'creationTime':
        return 180;
        break;
      case 'operate':
        return 100;
        break;
      default:
        return 60;
        break;
    }
  }

  /**编辑 */
  EditUsedCar(id) {
    this.router.navigate([`/dealer-platform/used-car/${id}/edit`])
  }
  /**删除二手车 */
  SiteDelete(data) {
    this._confirmationService
    .warn(`${data.name}`, '确定要删除这个二手车吗?', {})
    .subscribe(async (status: Confirmation.Status) => {
      if (status == 'confirm') {
        // const messageid = this.message.loading('删除中', { nzDuration: 0 }).messageId;
        this._UsedCarService.delete(data.id).subscribe(res => {
            this.getUsedCarList()
            // this.message.remove(messageid);
            // this.message.info('已完成');
        })
      }
      if (status == 'reject') return
    });
  }
   /**
 * 筛选方法
 */
   searchSite() {
    this.page.skipCount=0
    this.getUsedCarList()
  }


  setPage(event) {
    this.page=event
    this.getUsedCarList();
  }


}
