/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { UsedCarConsultationService } from '../../proxy/dealer-platform/used-cars';

@Component({
  selector: 'lib-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss','../../style/index.scss']
})
export class ListComponent {

  constructor(
    private _UsedCarConsultationService: UsedCarConsultationService,
  ) { }

  async ngOnInit(): Promise<void> {
    //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
    //Add 'implements OnInit' to the class.


    this.getUsedCarConsultationList()
  }
  
  /**二手车列表 */
  UsedCarList: any[] = []
  /**查询条件 */
  search: any = {
    filter: '',
  }
  /**二手车列表-分页 */
  skipCount: number = 0
  /**二手车列表-每页最大个数 */
  maxResultCount: number = 15
  /**二手车列表--总数据 */
  pageTotal: number

  /**获取二手车列表 */
  getUsedCarConsultationList() {
    this._UsedCarConsultationService.getList({
      ...this.search,
      skipCount: this.skipCount * this.maxResultCount,
      maxResultCount: this.maxResultCount
    }).subscribe(async (res) => {


      this.UsedCarList = res.items
      this.pageTotal = res.totalCount
    })
  }
  /**
 * 筛选方法
 */
  searchSite() {
    this.getUsedCarConsultationList()
  }
  /**翻页 */
  nzPageIndexChange(event) {
    this.skipCount = event - 1
    this.getUsedCarConsultationList()
  }
}
