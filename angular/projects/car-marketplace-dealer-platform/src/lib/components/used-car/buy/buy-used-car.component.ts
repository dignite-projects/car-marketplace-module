import { Component, TemplateRef, ViewChild } from '@angular/core';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { BuyUsedCarService } from '../../../proxy/dealer-platform/used-cars';

@Component({
  selector: 'lib-buy-used-car',
  templateUrl: './buy-used-car.component.html',
  styleUrls: ['./buy-used-car.component.scss']
})
export class BuyUsedCarComponent {

  constructor(
    private _BuyUsedCarService: BuyUsedCarService,
  ) {

  }
  /**二手车列表 */
  BuyUsedCarList: any[] = []
  /**查询条件 */
  search: any = {
    filter: '',
  }

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


  @ViewChild('creationTimeCol') creationTimeCol: TemplateRef<any>;
  @ViewChild('reservationTimeCol') reservationTimeCol: TemplateRef<any>;
  ngOnInit() {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    // this.getBuyUsedCarList()
  }
  /**获取二手车列表 */
  getBuyUsedCarList() {
    this._BuyUsedCarService.getList({
      ...this.search,
      skipCount: this.page.skipCount * this.page.maxResultCount,
      maxResultCount: this.page.maxResultCount
    }).subscribe(async (res) => {
      this.loadingIndicator = false;
      this.BuyUsedCarList = res.items;
      this.page.total = res.totalCount;
      this.columns = [
        {
          name: '二手车名称', prop: 'usedCar.name'
        },
        {
          name: '预约时间', prop: 'reservationTime',
          cellTemplate: this.reservationTimeCol
        },
        { name: '预约人', prop: 'contactPerson' },
        { name: '联系方式', prop: 'contactNumber' },
        {
          name: '创建时间', prop: 'creationTime',
          cellTemplate: this.creationTimeCol,
        },
      ].map(el => ({
        ...el,
        minWidth: this.getCloumnWidth(el.prop)
      }));

    })
  }
  /**获取列的最小宽度 */
  getCloumnWidth(value) {
    switch (value) {
      case 'name':
        return 240;
        break;
      case 'reservationTime':
        return 120;
        break;
      case 'creationTime':
        return 160;
        break;
      case 'operate':
        return 100;
        break;
      default:
        return 60;
        break;
    }
  }
  /**
* 筛选方法
*/
  searchSite() {
    this.page.skipCount=0
    this.getBuyUsedCarList()
  }


  setPage(pagedata) {
    this.page=pagedata
    this.getBuyUsedCarList();
  }
}
