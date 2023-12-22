/* eslint-disable @angular-eslint/no-empty-lifecycle-method */
/* eslint-disable @angular-eslint/use-lifecycle-interface */
import { Component, Injectable } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { NzMessageService } from 'ng-zorro-antd/message';
import { NzModalService } from 'ng-zorro-antd/modal';
import { BrandService, ModelService, TrimService } from '../../proxy/public/cars';
import { CarService } from '../../services/car.service';
import { UsedCarService } from '../../proxy/dealer-platform/cars';
@Injectable({
  providedIn: 'root'
})
@Component({
  selector: 'lib-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss', '../../style/index.scss']
})
export class CarListComponent {
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


    this.getUsedCarList(1)
  }
  /**品牌ID */
  brandID: string = ''
  /**品牌列表 */
  brandList: any[] = []
  /**车型ID */
  modelID: string = ''
  /**车型列表 */
  modelList: any[] = []
  /**车款列表 */
  trimList: any[] = []
  /**二手车状态列表 */
  carStatusList: any[any] = []
  /**二手车列表 */
  UsedCarList: any[] = []
  /**查询条件 */
  search: any = {
    filter: '',
    status: '',
    trimId: ''
  }
  /**二手车列表-分页 */
  skipCount: number = 0
  /**二手车列表-每页最大个数 */
  maxResultCount: number = 15
  /**二手车列表--总数据 */
  pageTotal: number=0

  /**获取二手车列表 */
  getUsedCarList(num?) {
    // console.log('获取二手车列表',num);
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



  /**获取品牌列表 */
  getBrandList() {
    return new Promise((resolve, rejects) => {
      this._BrandService.getList().subscribe((res: any) => {
        // console.log(res.items, '获取品牌列表');
        resolve(new Array(...res.items))
      })
    })
  }
  /**品牌列表改变 */
  async BrandChange(event) {
    // console.log('品牌列表改变', event);
    this.modelList = await this.getModelList(event)
  }
  /**获取车型列表 */
  getModelList(brandId):any {
    return new Promise((resolve, rejects) => {
      this._ModelService.getList({
        brandId: brandId
      }).subscribe(res => {
        resolve(new Array(...res.items))
      })
    })
  }
  /**车型列表选择改变 */
  async ModelChange(event) {
    this.trimList = await this.gettrimList(event)
  }
  /**获取车款列表 */
  gettrimList(ModelId):any {
    return new Promise((resolve, rejects) => {
      this._TrimService.getList({
        modelId: ModelId
      }).subscribe(res => {
        resolve(new Array(...res.items))
      })
    })
  }
  /**编辑 */
  EditUsedCar(data) {
    this.router.navigate([`/dealer-platform/userd-car/${data.id}/edit`])
  } 
  /**删除二手车 */
  SiteDelete(data) {
    this.modal.confirm({
      nzTitle: '确定要删除这个二手车吗',
      nzContent: `<b style="color: red;">${data?.name}</b>`,
      nzOkText: '确认',
      nzOkType: 'primary',
      nzOnOk: () => {
        const messageid = this.message.loading('删除中', { nzDuration: 0 }).messageId;
        this._UsedCarService.delete(data.id).subscribe(res => {
          setTimeout(async () => {
            this.getUsedCarList('删除二手车')
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
    this.getUsedCarList('筛选方法')
  }
  /**翻页 */
  nzPageIndexChange(event) {
    this.skipCount = event - 1
    this.getUsedCarList('翻页')
  }
}
