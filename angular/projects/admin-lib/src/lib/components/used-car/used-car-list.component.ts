/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BrandService, ModelService, TrimService } from '../../proxy/public/cars';
import { CarService } from '../../services';
import { UsedCarService } from '../../proxy/admin/used-cars';

@Component({
  selector: 'lib-used-car-list',
  templateUrl: './used-car-list.component.html',
  styleUrls: ['./used-car-list.component.scss','../../style/index.scss']
})
export class UsedCarListComponent {
  constructor(
    private _UsedCarService: UsedCarService,
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
    this.carStatusList = await this._CarService.getcarStatusName()
    this.getUsedCarList()
  }
  /**二手车状态列表 */
  carStatusList: any[any] = []
  /**二手车列表 */
  UsedCarList: any[] = []
  /**查询条件 */
  search: any = {
    usedCarId: '',
  }
  /**二手车列表-分页 */
  skipCount: number = 0
  /**二手车列表-每页最大个数 */
  maxResultCount: number = 15
  /**二手车列表--总数据 */
  pageTotal: number

  /**获取二手车列表 */
  getUsedCarList(num?) {
    this._UsedCarService.getList({
      ...this.search,
      sorting: '',
      skipCount: this.skipCount * this.maxResultCount,
      maxResultCount: this.maxResultCount
    }).subscribe(async (res) => {
      this.UsedCarList = res.items
      this.pageTotal = res.totalCount
    })
  }



  /**编辑 */
  EditUsedCar(data) {
    const params: NavigationExtras = {
      queryParams: {
        usedCarId: data.id
      }, // 传递的参数
    };
    this.router.navigate(['/car-marketplace/userd-car/create'], params)
  } 
  /**删除二手车 */
  SiteDelete(data) {
    this.modal.confirm({
      nzTitle: '确定要删除这个二手车吗',
      nzContent: `<b style="color: red;">${data.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        const messageid = this.message.loading('删除中', { nzDuration: 0 }).messageId;
        this._UsedCarService.delete(data.id).subscribe(res => {
          setTimeout(async () => {
            this.getUsedCarList()
            this.message.remove(messageid);
            this.message.info('已完成');
          }, 1200)
        })
      },
      nzCancelText: '取消',
      nzOnCancel: () => {
      }
    });


  }
  /**
 * 筛选方法
 */
  searchSite() {
    this.getUsedCarList()
  }
  /**翻页 */
  nzPageIndexChange(event) {
    this.skipCount = event - 1
    this.getUsedCarList()
  }
}
