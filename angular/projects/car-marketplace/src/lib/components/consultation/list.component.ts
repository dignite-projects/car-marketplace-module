/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { Router, NavigationExtras } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { UsedCarService } from 'projects/car-marketplace/proxy/dealer-platform/cars';
import { UsedCarConsultationService } from 'projects/car-marketplace/proxy/dealer-platform/used-cars/used-car-consultation.service';
import { BrandService, ModelService, TrimService } from 'projects/car-marketplace/proxy/public/cars';
import { CarService } from 'projects/car-marketplace/src/services/car.service';

@Component({
  selector: 'lib-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss','../../../style/index.scss']
})
export class ListComponent {

  constructor(
    private _UsedCarConsultationService: UsedCarConsultationService,
    private _CarService: CarService,
    private router: Router,
    private message: NzMessageService,
    private modal: NzModalService,
    private _BrandService: BrandService,
    private _ModelService: ModelService,
    private _TrimService: TrimService,
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
  skipCount: number = 2
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
