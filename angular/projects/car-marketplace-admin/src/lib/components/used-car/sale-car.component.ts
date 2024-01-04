import { Component, TemplateRef, ViewChild } from '@angular/core';
// import { SaleUsedCarService } from '../../../../proxy/src/proxy/admin/used-cars';
import { ColumnMode } from '@swimlane/ngx-datatable';
import { SaleUsedCarService } from '../../proxy/admin/used-cars';

@Component({
  selector: 'lib-sale-car',
  templateUrl: './sale-car.component.html',
  styleUrls: ['./sale-car.component.scss']
})
export class SaleCarComponent {

  constructor(

    private _SaleUsedCarService: SaleUsedCarService

  ) { }

  @ViewChild('nameCol') nameCol: TemplateRef<any>;
  @ViewChild('statusCol') statusCol: TemplateRef<any>;
  @ViewChild('registrationDateCol') registrationDateCol: TemplateRef<any>;
  @ViewChild('creationTimeCol') creationTimeCol: TemplateRef<any>;
  @ViewChild('operateCol') operateCol: TemplateRef<any>;

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
  /**翻页 */
  setPage(event) {
    this.page = event
    this.getsaleCarList();
  }

  log(val) {
    console.log(val, '1111111111');

  }
  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.
    //  this.getsaleCarList()
  }

  /**卖车列表 */
  saleCarList: any[any] = []

  /**车商列表-分页 */
  skipCount: number = 0

  /**车商列表-每页最大个数 */
  maxResultCount: number = 15

  /**车商列表--总数据 */
  pageTotal: number = 0



  /**获取二手车列表 */
  getsaleCarList() {
    return new Promise<void>((resolve, reject) => {
      this._SaleUsedCarService.getList({
        skipCount: this.page.skipCount * this.page.maxResultCount,
        maxResultCount: this.page.maxResultCount,
      }).subscribe(res => {
        this.saleCarList = res.items
        this.loadingIndicator = false;
        this.page.total = res.totalCount;
        this.columns = [
          {
            name: '操作', prop: 'operate',
            cellTemplate: this.operateCol,
          },
          {
            name: '品牌分组', prop: 'model.group',
            // cellTemplate: this.nameCol,
            minWidth: 200,
          },
          { name: '车型', prop: 'model.name' },
          { name: '总里程(公里数)', prop: 'totalMileage' },
          { name: '联系人', prop: 'contactPerson' },
          { name: '联系电话', prop: 'contactNumber' },
          {
            name: '地址', prop: 'address',
            minWidth: 160,
          },
          {
            name: '初次上牌日期', prop: 'registrationDate',
            cellTemplate: this.registrationDateCol,
            minWidth: 160,
          },
          {
            name: '创建时间', prop: 'creationTime',
            cellTemplate: this.creationTimeCol,
            minWidth: 160,
          },

        ].map(el => ({
          ...el,
          minWidth: this.getCloumnWidth(el.prop)
        }));

        resolve()
      })

    })

  }
  /**获取列的最小宽度 */
  getCloumnWidth(value) {
    switch (value) {
      // case 'name':
      //   return 280;
      //   break;
      case 'address':
        return 180;
        break;
      case 'contactNumber':
        return 130;
        break;
      case 'registrationDate':
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



}
